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
        private TestService _testService;
        private readonly IGenericRepository<Question> _questionRepository;

        public TestQuestionsController(
            TestService testService,
            IGenericRepository<Question> questionRepository
        )
        {
            _testService = testService;
            _questionRepository = questionRepository;
        }

        // GET: api/TestQuestions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Question>>> GetTestQuestions(string category)
        {
            var questions = await _questionRepository.GetAllAsync();
            return Ok(questions);
        }

        // GET: api/TestQuestions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetTestQuestion(int id)
        {
            var testQuestion = await _questionRepository.GetByIdAsync(id);

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

            await _questionRepository.UpdateAsync(testQuestion);

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
            await _questionRepository.AddAsync(result);

            return CreatedAtAction("GetTestQuestion", new { id = result.Id }, testQuestion);
        }

        // DELETE: api/TestQuestions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestQuestion(int id)
        {
            var testQuestion = await _questionRepository.GetByIdAsync(id);
            if (testQuestion == null)
            {
                return NotFound();
            }

            await _questionRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
