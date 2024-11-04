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
                CorrectAnswer =
                    testQuestion.Type == TestType.TextAnswer ? testQuestion.CorrectAnswer : "",
                Type = testQuestion.Type,
                TestOptions =
                    testQuestion.Type == TestType.SingleChoice
                    || testQuestion.Type == TestType.MultipleChoice
                        ? testQuestion
                            .TestOptions.Select(x => new TestOption
                            {
                                OptionText = x.OptionText,
                                IsCorrect = x.IsCorrect,
                            })
                            .ToList()
                        : [],
            };
            _context.Questions.Add(result);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestQuestion", new { id = result.Id }, testQuestion);
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
