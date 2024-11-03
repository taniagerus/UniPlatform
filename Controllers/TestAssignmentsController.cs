using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniPlatform.DB;
using UniPlatform.Services;
using UniPlatform.DB.Entities;
using UniPlatform.ViewModels;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;

namespace UniPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAssignmentsController : ControllerBase
    {
        private readonly PlatformDbContext _context;
        private TestService _testService;
        public TestAssignmentsController(PlatformDbContext context, TestService testService)
        {
            _context = context;
            _testService = testService;
        }


        // GET: api/TestAssignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestAssignment>>> GetTestAssignments()
        {
            return await _context.TestAssignments.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult<Question>> PostTestAssignment(CreateTestAssignmentRequest test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryList = test.Categories;
            var questions = new List<Question>();
            foreach (var category in categoryList)
            {
                questions.AddRange(_testService.GetRandomTestQuestionsForAssignment(category, test.NumberOfQuestions));
            }
            var testConfiguration = new TestAssignment
            {
                Title = test.Title,
                StudentId = test.StudentId,
                StartTime = test.StartTime,
                EndTime = test.EndTime,
                TimeLimit = test.TimeLimit,
                NumberOfQuestions = test.NumberOfQuestions,
                Questions = questions.Select(x => new TestQuestion { QuestionId = x.Id }).ToList()
            };
            testConfiguration.SetCategories(test.Categories);
            _context.TestAssignments.Add(testConfiguration);
            await _context.SaveChangesAsync();

            var result = new TestAssignmentViewModel
            {
                Id = testConfiguration.Id,
                Title = testConfiguration.Title,
                StudentId = testConfiguration.StudentId,
                StartTime = testConfiguration.StartTime,
                EndTime = testConfiguration.EndTime,
                TimeLimit = testConfiguration.TimeLimit,
                NumberOfQuestions = testConfiguration.NumberOfQuestions,
                Categories = categoryList,
                Questions = questions.Select(q => new QuestionViewModel
                {
                    Category = q.Category,
                    CorrectAnswer = q.CorrectAnswer,
                    QuestionText = q.QuestionText,
                    Type = q.Type
                }).ToList()
            };

            return CreatedAtAction("GetTestAssignment", new { id = testConfiguration.Id }, result);
        }
        [HttpPost, Route("TestToCheck")]
        public async Task<ActionResult<TestToCheckViewModel>> SendTestToCheck(TestToCheckViewModel test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var answers = new List<Answer>();
            var selectedOptions = new List<SelectedOptions>();
            foreach (var ans in test.Answers)
            {
                var question = await _context.Questions.FindAsync(ans.QuestionId);
                var answer = new Answer
                {
                    QuestionId = ans.QuestionId,
                    TestAssignmentId = test.TestAssignmentId
                };
                if (question.Type == TestType.TextAnswer)
                {
                    answer.TextAnswer = ans.TextAnswer;
                }
                else if (question.Type == TestType.SingleChoice || question.Type == TestType.MultipleChoice)
                {
                    answer.TextAnswer = "";
                    foreach (var option in ans.SelectedOptions)
                    {
                        var selectedOption = new SelectedOptions
                        {
                            QuestionId = ans.QuestionId,
                            TestOptionId = option.TestOptionId
                        };
                        selectedOptions.Add(selectedOption);
                    }
                }
                else
                {
                    return BadRequest($"Unsupported question type for question {ans.QuestionId}");
                }

                answers.Add(answer);
            }
                await _context.StudentAnswers.AddRangeAsync(answers);
                await _context.SelectedOptions.AddRangeAsync(selectedOptions);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetTestToCheck", new { id = test.TestAssignmentId }, test);
        
        }


        [HttpGet("TestToCheck/{id}")]
        public async Task<ActionResult<TestToCheckViewModel>> GetTestToCheck(int id)
        {
            var test = await _context.TestAssignments
                .Include(t => t.Answers)
                    .ThenInclude(a => a.SelectedOptions)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (test == null)
            {
                return NotFound();
            }

            var result = new TestToCheckViewModel
            {
                TestAssignmentId = test.Id,
                StudentId = test.StudentId,
                Answers = test.Answers.Select(x => new AnswerViewModel
                {
                    QuestionId = x.QuestionId,
                    TextAnswer = x.TextAnswer,
                    SelectedOptions = x.SelectedOptions.Select(so => new SelectedOptionViewModel
                    {
                        
                        TestOptionId = so.Id
                    }).ToList()
                }).ToList()
            };

            return Ok(result);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<TestAssignmentViewModel>> GetTestAssignment(int id)
        {
            var testAssignment = await _context.TestAssignments.FindAsync(id);

            // Розділяємо категорії на список
            var categoryList = testAssignment.Categories.Split(';').ToList();
            if (testAssignment == null)
            {
                return NotFound();
            }
            var questions = _testService.GetQuestions(id);
            var vm = new TestAssignmentViewModel()
            {
                Id = testAssignment.Id,
                Title = testAssignment.Title,
                StudentId = testAssignment.StudentId,
                StartTime = testAssignment.StartTime,
                EndTime = testAssignment.EndTime,
                TimeLimit = testAssignment.TimeLimit,
                Categories = testAssignment.GetCategories(),
                NumberOfQuestions = testAssignment.NumberOfQuestions,
                Questions = questions.Select(q => new QuestionViewModel
                {
                    Id = q.Id,
                    Category = q.Category,
                    QuestionText = q.QuestionText,
                    Type = q.Type,
                    CorrectAnswer = q.CorrectAnswer,

                    TestOptions = _testService.GetTestOption(q).Select(t => new OptionViewModel
                    {
                        Id = t.Id,
                        OptionText = t.OptionText,
                    }).ToList()

                }).ToList()
            };
            return Ok(vm);
        }

        // PUT: api/TestAssignments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestAssignment(int id, TestAssignment testAssignment)
        {
            if (id != testAssignment.Id)
            {
                return BadRequest();
            }

            _context.Entry(testAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestAssignmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        // DELETE: api/TestAssignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestAssignment(int id)
        {
            var testAssignment = await _context.TestAssignments.FindAsync(id);
            if (testAssignment == null)
            {
                return NotFound();
            }

            _context.TestAssignments.Remove(testAssignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestAssignmentExists(int id)
        {
            return _context.TestAssignments.Any(e => e.Id == id);
        }
    }
}
