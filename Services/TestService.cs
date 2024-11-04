using Microsoft.Identity.Client;
using UniPlatform.DB;
using UniPlatform.DB.Entities;
using UniPlatform.DB.Repositories;

public class TestService
{
    private readonly PlatformDbContext _context;
    private readonly IGenericRepository<Question> _genericRepository;
    private readonly IQuestionRepository _questionRepository;

    public TestService(
        PlatformDbContext context,
        IGenericRepository<Question> generic,
        IQuestionRepository questionRepository
    )
    {
        _context = context;
        _genericRepository = generic;
        _questionRepository = questionRepository;
    }

    public async Task<List<Question>> GetRandomTestQuestionsForAssignment(
        string category,
        int numberOfQuestions
    )
    {
        return (
            await _questionRepository.GetRandomTestQuestionsAsync(category, numberOfQuestions)
        ).ToList();
    }

    public List<Question> GetQuestions(int id)
    {
        List<TestQuestion> testQuestions = GetTestQuestionsForAssignment(id);
        List<int> questionsIds = testQuestions.Select(t => t.QuestionId).ToList();
        List<Question> result = GetQuestionsByIdsFromDb(questionsIds);
        return result;
    }

    public List<TestQuestion> GetTestQuestionsForAssignment(int id)
    {
        return _context.TestQuestions.Where(e => e.TestAssignmentId == id).ToList();
    }

    //TestOptions = q.TestOptions.Select(t => new OptionViewModel
    //                {
    //                    Id = t.Id,
    //                    OptionText = t.OptionText,
    //                }).ToList()

    public List<Question> GetQuestionsByIdsFromDb(List<int> ids)
    {
        var questions = _context.Set<Question>().Where(e => ids.Contains(e.Id)).ToList();
        return questions;
    }

    public List<TestOption> GetTestOption(Question question)
    {
        var testOptions = _context
            .Set<TestOption>()
            .Where(to => to.QuestionId == question.Id)
            .ToList();

        return testOptions;
    }

    //TestOptions = q.TestOptions.Select(t => new OptionViewModel
    //                {
    //                    Id = t.Id,
    //                    OptionText = t.OptionText,
    //                }).ToList()
    // ��������� ���� ������� �����
    //public void AddTestCategory(string name, string description, int courseId)
    //{
    //	var category = new TestCategory
    //	{
    //		Name = name,
    //		CourseId = courseId
    //	};

    //	_context.TestCategories.Add(category);
    //	_context.SaveChanges();
    //}

    //// ��������� ������ ������� � ��������
    //public void AddTestQuestion(string questionText, TestType type, DifficultyLevel difficulty, int categoryId)
    //{
    //	var question = new TestQuestion
    //	{
    //		QuestionText = questionText,
    //		Type = type,
    //		Difficulty = difficulty,
    //		CategoryId = categoryId
    //	};

    //	_context.TestQuestions.Add(question);
    //	_context.SaveChanges();
    //}

    //// ��������� ������ ������� ������
    //public void AddTestOption(string optionText, int questionId, bool isCorrect = false, int? correctOrder = null, string matchingPair = null)
    //{
    //	var option = new TestOption
    //	{
    //		OptionText = optionText,
    //		QuestionId = questionId,
    //		IsCorrect = isCorrect,
    //		CorrectOrder = correctOrder,
    //		MatchingPair = matchingPair
    //	};

    //	_context.TestOptions.Add(option);
    //	_context.SaveChanges();
    //}
}
