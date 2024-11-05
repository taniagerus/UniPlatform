using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniPlatform.DB.Entities;
using UniPlatform.DB.Repositories;
using UniPlatform.ViewModels;

namespace UniPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestAssignmentsController : ControllerBase
    {
        private TestService _testService;
        private readonly IMapper _mapper;

        private readonly IGenericRepository<TestAssignment> _testRepository;
        private readonly IGenericRepository<Question> _questionRepository;
        private readonly IGenericRepository<Answer> _answerRepository;
        private readonly IGenericRepository<SelectedOption> _selectedOptionsRepository;
        private readonly ITestAssignmentRepository _testAssignmentRepository;

        public TestAssignmentsController(
            TestService testService,
            IGenericRepository<TestAssignment> testRepository,
            IGenericRepository<Question> questionRepository,
            IGenericRepository<Answer> answerRepository,
            IGenericRepository<SelectedOption> selectedOptionsRepository,
            ITestAssignmentRepository testAssignmentRepository,
            IMapper mapper
        )
        {
            _testService = testService;
            _testRepository = testRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _selectedOptionsRepository = selectedOptionsRepository;
            _testAssignmentRepository = testAssignmentRepository;
            _mapper = mapper;
        }

        // GET: api/TestAssignments
        [HttpGet]
        [Authorize(Roles = "Lecturer")]
        public async Task<ActionResult<IEnumerable<TestAssignment>>> GetTestAssignments()
        {
            var result = await _testRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Lecturer")]
        public async Task<ActionResult<Question>> PostTestAssignment(
            CreateTestAssignmentRequest test
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validationResult = await _testService.ValidateQuestionsPerCategory( test );

            if (!validationResult.IsSuccess)
            {                
                return BadRequest(validationResult.Error);
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

            var result = _mapper.Map<TestAssignment, TestAssignmentViewModel>(testConfiguration);

            result.Questions = questions
                .Select(q => _mapper.Map<Question, QuestionViewModel>(q))
                .ToList();

            //var result = new TestAssignmentViewModel
            //{
            //    Id = testConfiguration.Id,
            //    Title = testConfiguration.Title,
            //    StudentId = testConfiguration.StudentId,
            //    StartTime = testConfiguration.StartTime,
            //    EndTime = testConfiguration.EndTime,
            //    TimeLimit = testConfiguration.TimeLimit,
            //    NumberOfQuestions = testConfiguration.NumberOfQuestions,
            //    Questions = questions
            //        .Select(q => _mapper.Map<Question, QuestionViewModel>(q))
            //        .ToList(),
            //};
            return CreatedAtAction(nameof(GetTestAssignment), new { id = testConfiguration.Id }, result);
        }

        [HttpPost, Route("TestToCheck")]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult<BaseResult<int>>> SendTestToCheck(TestToCheckViewModel test)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _testService.CalculateScore(test);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(
                nameof(GetTestAssignmentForStudent),
                new { id = test.TestAssignmentId },
                result.Data
            );
        }

        [HttpGet("StudentTestAssignment/{id}")]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult<TestAssignmentViewModel>> GetTestAssignmentForStudent(int id)
        {
            var result = await _testService.GetTestAssignmentAsync(id, false);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Lecturer")]
        public async Task<ActionResult<TestAssignmentViewModel>> GetTestAssignment(int id)
        {
            var result = await _testService.GetTestAssignmentAsync(id, true);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Data);
        }

        // PUT: api/TestAssignments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Lecturer")]
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
