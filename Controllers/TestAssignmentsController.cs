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
            var questions = _testService.GetRandomTestQuestionsForAssignment(test.Category, test.NumberOfQuestions);
            var testConfiguration = new TestAssignment
            {
                Title = test.Title,
                StudentId = test.StudentId,
                StartTime = test.StartTime,
                EndTime = test.EndTime,
                TimeLimit = test.TimeLimit,
                NumberOfQuestions = test.NumberOfQuestions,
                Category = test.Category,
                Questions = questions.Select(x => new TestQuestion { QuestionId = x.Id }).ToList()
            };

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
                Category = testConfiguration.Category,
                Questions = questions.Select(q => new QuestionViewModel
                {
                    Category = q.Category,
                    CorrectAnswer = q.CorrectAnswer,
                    QuestionText = q.QuestionText,
                    Type = q.Type
                }).ToList()
            };

            return CreatedAtAction("GetTestQuestion", new { id = testConfiguration.Id }, result);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<TestAssignmentViewModel>> GetTestAssignment(int id)
        {
            var testAssignment = await _context.TestAssignments.FindAsync(id);

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
                Category=testAssignment.Category,
                NumberOfQuestions = testAssignment.NumberOfQuestions,
                Questions = questions.Select(q => new QuestionViewModel
                {
                    Id = q.Id,
                    Category = q.Category,
                    QuestionText = q.QuestionText,
                    Type = q.Type,
                    CorrectAnswer = q.CorrectAnswer, 
                   
                    TestOptions = _testService.GetTestOption(q).Select(t=>new OptionViewModel
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
