using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniPlatform.DB;
using UniPlatform.DB.Entities;
using UniPlatform.DB.Repositories;
using UniPlatform.Services;
using UniPlatform.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace UniPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAssignmentsController : ControllerBase
    {
        private TestService _testService;
        private readonly IGenericRepository<TestAssignment> _testRepository;
        private readonly IGenericRepository<Question> _questionRepository;
        private readonly IGenericRepository<Answer> _answerRepository;
        private readonly IGenericRepository<SelectedOptions> _selectedOptionsRepository;
        private readonly ITestAssignmentRepository _testAssignmentRepository;

        public TestAssignmentsController(
            TestService testService,
            IGenericRepository<TestAssignment> testRepository,
            IGenericRepository<Question> questionRepository,
            IGenericRepository<Answer> answerRepository,
            IGenericRepository<SelectedOptions> selectedOptionsRepository,
            ITestAssignmentRepository testAssignmentRepository
        )
        {
            _testService = testService;
            _testRepository = testRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _selectedOptionsRepository = selectedOptionsRepository;
            _testAssignmentRepository = testAssignmentRepository;
        }

        // GET: api/TestAssignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestAssignment>>> GetTestAssignments()
        {
            var result = await _testRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Question>> PostTestAssignment(
            CreateTestAssignmentRequest test
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var questions = new List<Question>();
            foreach (var categoryQuestion in test.CategoryQuestions)
            {
                questions.AddRange(
                    await _testService.GetRandomTestQuestionsForAssignment(
                        categoryQuestion.Category,
                        categoryQuestion.QuestionCount
                    )
                );
            }

            var testConfiguration = new TestAssignment
            {
                Title = test.Title,
                StudentId = test.StudentId,
                StartTime = test.StartTime,
                EndTime = test.EndTime,
                TimeLimit = test.TimeLimit,
                NumberOfQuestions = test.CategoryQuestions.Sum(cq => cq.QuestionCount),
                Questions = questions.Select(x => new TestQuestion { QuestionId = x.Id }).ToList(),
                Categories = string.Join(
                    ";",
                    test.CategoryQuestions.Select(x => x.Category).Distinct()
                ),
            };

            await _testRepository.AddAsync(testConfiguration);
            var result = new TestAssignmentViewModel
            {
                Id = testConfiguration.Id,
                Title = testConfiguration.Title,
                StudentId = testConfiguration.StudentId,
                StartTime = testConfiguration.StartTime,
                EndTime = testConfiguration.EndTime,
                TimeLimit = testConfiguration.TimeLimit,
                NumberOfQuestions = testConfiguration.NumberOfQuestions,

                Questions = questions
                    .Select(q => new QuestionViewModel
                    {
                        Category = q.Category,
                        CorrectAnswer = q.CorrectAnswer,
                        QuestionText = q.QuestionText,
                        Type = q.Type,
                    })
                    .ToList(),
            };
            return CreatedAtAction("GetTestAssignment", new { id = testConfiguration.Id }, result);
        }

        [HttpPost, Route("TestToCheck")]
        public async Task<ActionResult<TestToCheckViewModel>> SendTestToCheck(
            TestToCheckViewModel test
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var answers = new List<Answer>();
            var selectedOptions = new List<SelectedOptions>();
            foreach (var ans in test.Answers)
            {
                var question = await _questionRepository.GetByIdAsync(ans.QuestionId);
                var answer = new Answer
                {
                    QuestionId = ans.QuestionId,
                    TestAssignmentId = test.TestAssignmentId,
                };
                if (question.Type == TestType.TextAnswer)
                {
                    answer.TextAnswer = ans.TextAnswer;
                }
                else if (
                    question.Type == TestType.SingleChoice
                    || question.Type == TestType.MultipleChoice
                )
                {
                    answer.TextAnswer = "";
                    foreach (var option in ans.SelectedOptions)
                    {
                        var selectedOption = new SelectedOptions
                        {
                            QuestionId = ans.QuestionId,
                            TestOptionId = option.TestOptionId,
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
            await _answerRepository.AddManyAsync(answers);
            await _selectedOptionsRepository.AddManyAsync(selectedOptions);
            return CreatedAtAction("GetTestToCheck", new { id = test.TestAssignmentId }, test);
        }

        [HttpGet("TestToCheck/{id}")]
        public async Task<ActionResult<TestToCheckViewModel>> GetTestToCheck(int id)
        {
            var test = await _testAssignmentRepository.GetTestByIdAsync(id);

            if (test == null)
            {
                return NotFound();
            }

            var result = new TestToCheckViewModel
            {
                TestAssignmentId = test.Id,
                StudentId = test.StudentId,
                Answers = test
                    .Answers.Select(x => new AnswerViewModel
                    {
                        QuestionId = x.QuestionId,
                        TextAnswer = x.TextAnswer,
                        SelectedOptions = x
                            .SelectedOptions.Select(so => new SelectedOptionViewModel
                            {
                                TestOptionId = so.Id,
                            })
                            .ToList(),
                    })
                    .ToList(),
            };

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TestAssignmentViewModel>> GetTestAssignment(int id)
        {
            var testAssignment = await _testRepository.GetByIdAsync(id);
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

                NumberOfQuestions = testAssignment.NumberOfQuestions,
                Questions = questions
                    .Select(q => new QuestionViewModel
                    {
                        Id = q.Id,
                        Category = q.Category,
                        QuestionText = q.QuestionText,
                        Type = q.Type,
                        CorrectAnswer = q.CorrectAnswer,

                        TestOptions = _testService
                            .GetTestOption(q)
                            .Select(t => new OptionViewModel
                            {
                                Id = t.Id,
                                OptionText = t.OptionText,
                            })
                            .ToList(),
                    })
                    .ToList(),
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

            await _testRepository.UpdateAsync(testAssignment);
            return Ok(testAssignment);
        }

        // DELETE: api/TestAssignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestAssignment(int id)
        {
            var testAssignment = await _testRepository.GetByIdAsync(id);
            if (testAssignment == null)
            {
                return NotFound();
            }

            _testRepository.DeleteAsync(testAssignment.Id);

            return NoContent();
        }
    }
}
