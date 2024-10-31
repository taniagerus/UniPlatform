using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniPlatform.DB;
using UniPlatform.DB.Entities;
using UniPlatform.ViewModels;

namespace UniPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestQuestionsController : ControllerBase
    {
        private readonly PlatformDbContext _context;
        private TestService _testService;
        public TestQuestionsController(PlatformDbContext context, TestService testService)
        {
            _context = context;
            _testService = testService;
        }

        // GET: api/TestQuestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetTestQuestions(string category)
        {
            return await _context.Questions.ToListAsync();
        }

        // GET: api/TestQuestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetTestQuestion(int id)
        {
            var testQuestion = await _context.Questions.FindAsync(id);

            if (testQuestion == null)
            {
                return NotFound();
            }

            return testQuestion;
        }


        // PUT: api/TestQuestions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestQuestion(int id, Question testQuestion)
        {
            if (id != testQuestion.Id)
            {
                return BadRequest();
            }

            _context.Entry(testQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestQuestionExists(id))
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

        // POST: api/TestQuestions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Route("TestQuestion")]
        public async Task<ActionResult<Question>> PostTestQuestion(QuestionViewModel testQuestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = new Question
            {
                QuestionText = testQuestion.QuestionText,
                Category = testQuestion.Category,
                CorrectAnswer = testQuestion.CorrectAnswer,
                Type = testQuestion.Type,
                TestOptions = testQuestion.TestOptions.Select(x => new TestOption { OptionText = x.OptionText, IsCorrect = x.IsCorrect }).ToList()

            };
            _context.Questions.Add(result);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestQuestion", new { id = result.Id }, testQuestion);
        }
        [HttpPost, Route("TestAssignment")]
        public async Task<ActionResult<Question>> PostTestAssignment(CreateTestAssignmentRequest test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var questions = _testService.GetTestQuestionsForAssignment(test.Category, test.NumberOfQuestions);
            var testConfiguration = new TestAssignment
            {
                Title = test.Title,
                StudentId = test.StudentId,
                StartTime = test.StartTime,
                EndTime = test.EndTime,
                TimeLimit = test.TimeLimit,
                NumberOfQuestions = test.NumberOfQuestions,
                Category = test.Category,
            };

            _context.TestAssignments.Add(testConfiguration);
            await _context.SaveChangesAsync();

            var testQuestions = questions.Select(x => new TestQuestion { QuestionId = x.Id, TestAssignmentId=testConfiguration.Id }).ToList();
            _context.TestQuestions.AddRange(testQuestions);
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
        [HttpGet]
        public async Task<ActionResult<TestAssignment>> GetTestAssignment(int id)
        {
            var testAssignment = await _context.TestAssignments.FindAsync(id);

            if (testAssignment == null)
            {
                return NotFound();
            }
           var questions = testAssignment.Questions.ToList();

            return testAssignment;
        }
        // DELETE: api/TestQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestQuestion(int id)
        {
            var testQuestion = await _context.TestQuestions.FindAsync(id);
            if (testQuestion == null)
            {
                return NotFound();
            }

            _context.TestQuestions.Remove(testQuestion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestQuestionExists(int id)
        {
            return _context.TestQuestions.Any(e => e.Id == id);
        }
    }
}
