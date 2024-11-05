using AutoMapper;
using NuGet.Packaging;
using UniPlatform.DB;
using UniPlatform.DB.Entities;
using UniPlatform.DB.Repositories;
using UniPlatform.ViewModels;

public class TestService
{
    private readonly PlatformDbContext _context;
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Question> _genericRepository;
    private readonly IGenericRepository<TestAssignment> _testAssignmentRepository;
    private readonly IQuestionRepository _questionRepository;
    private readonly IGenericRepository<Answer> _answerRepository;
    private readonly IGenericRepository<SelectedOption> _selectedOptionsRepository;
    private readonly IGenericRepository<TestAttempt> _testAttemptRepository;

    public TestService(
        PlatformDbContext context,
        IMapper mapper,
        IGenericRepository<Question> generic,
        IQuestionRepository questionRepository,
        IGenericRepository<Answer> answerRepository,
        IGenericRepository<TestAttempt> testAttemptRepository,
        IGenericRepository<TestAssignment> testAssignmentRepository,
        IGenericRepository<SelectedOption> selectedOptionsRepository
    )
    {
        _context = context;
        _mapper = mapper;
        _genericRepository = generic;
        _questionRepository = questionRepository;
        _answerRepository = answerRepository;
        _testAttemptRepository = testAttemptRepository;
        _testAssignmentRepository = testAssignmentRepository;
        _selectedOptionsRepository = selectedOptionsRepository;
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

    public async Task<BaseResult<TestAttempt>> SaveStudentAnswersAsync(TestToCheckViewModel test)
    {
        var assignment = await _testAssignmentRepository.GetByIdAsync(test.TestAssignmentId);

        var answers = new List<Answer>();
        var selectedOptions = new List<SelectedOption>();
        foreach (var ans in test.Answers)
        {
            var question = await _genericRepository.GetByIdAsync(ans.QuestionId);
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
                    var selectedOption = new SelectedOption
                    {
                        QuestionId = ans.QuestionId,
                        TestOptionId = option.TestOptionId,
                    };
                    selectedOptions.Add(selectedOption);
                }
            }
            else
            {
                return new BaseResult<TestAttempt>()
                {
                    IsSuccess = false,
                    Error = $"Unsupported question type for question {ans.QuestionId}",
                };
            }

            
            answer.SelectedOptions.AddRange(selectedOptions);
            selectedOptions.Clear();
            answers.Add(answer);
        }

        var attempt = new TestAttempt
        {
            SubmittedAt = DateTime.UtcNow,
            TestAssignment = assignment,
            Answers = answers,
        };

        await _testAttemptRepository.AddAsync(attempt);
        return new BaseResult<TestAttempt>() { IsSuccess = true, Data = attempt };
    }

    public async Task<BaseResult<TestAssignmentViewModel>> GetTestAssignmentAsync(
        int assignmentId,
        bool withAnswers
    )
    {
        var testAssignment = await _testAssignmentRepository.GetByIdAsync(assignmentId);
        var categoryList = testAssignment.Categories.Split(';').ToList();
        if (testAssignment == null)
        {
            return new BaseResult<TestAssignmentViewModel>()
            {
                IsSuccess = false,
                Error = $"Test assignment is not found with id {assignmentId}",
            };
        }
        var questions = GetQuestions(assignmentId);
        var vm = new TestAssignmentViewModel()
        {
            Id = testAssignment.Id,
            Title = testAssignment.Title,
            StudentId = testAssignment.StudentId,
            StartTime = testAssignment.StartTime,
            EndTime = testAssignment.EndTime,
            TimeLimit = testAssignment.TimeLimit,
            MaxPoints = testAssignment.MaxPoints,
            NumberOfQuestions = testAssignment.NumberOfQuestions,
            Questions = questions
                .Select(q => new QuestionViewModel
                {
                    Id = q.Id,
                    Category = q.Category,
                    QuestionText = q.QuestionText,
                    CorrectAnswer = withAnswers ? q.CorrectAnswer : "",
                    Type = q.Type,
                    TestOptions = GetTestOption(q)
                        .Select(x =>
                        {
                            var option = _mapper.Map<TestOption, OptionViewModel>(x);
                            if (withAnswers)
                            {
                                return option;
                            }
                            else
                            {
                                option.IsCorrect = false;
                                return option;
                            }
                        })
                        .ToList(),
                })
                .ToList(),
        };

        return new BaseResult<TestAssignmentViewModel>() { IsSuccess = true, Data = vm };
    }

    public async Task<BaseResult<int>> CalculateScore(TestToCheckViewModel test)
    {
        var testAttemptResult = await SaveStudentAnswersAsync(test);
        if (!testAttemptResult.IsSuccess)
        {
            return new BaseResult<int>() { IsSuccess = false, Error = testAttemptResult.Error };
        }

        var assignmentResult = await GetTestAssignmentAsync(test.TestAssignmentId, true);
        if (!assignmentResult.IsSuccess)
        {
            return new BaseResult<int>() { IsSuccess = false, Error = assignmentResult.Error };
        }

        var score = ValidateTestAttempt(testAttemptResult.Data, assignmentResult.Data);

        return new BaseResult<int>() { IsSuccess = true, Data = score };
    }

    public int ValidateTestAttempt(TestAttempt attempt, TestAssignmentViewModel assignment)
    {
        var qustionsCount = assignment.Questions.Count;
        double koef = 0;

        foreach (var question in assignment.Questions)
        {
            var answer = attempt.Answers.SingleOrDefault(a => a.QuestionId == question.Id);
            koef += CalculateKoef(answer, question);        
        }

        var userScore= CalculateSummaryScore(assignment.MaxPoints ?? qustionsCount, qustionsCount, koef);

        return userScore;
    }

    private double CalculateKoef(Answer answer, QuestionViewModel question)
    {
        switch (question.Type)
        {
            case TestType.TextAnswer:
                return GetTextAnswerKoef(answer, question);
            case TestType.SingleChoice:
                return GetSingleChoiceKoef(answer, question);
            case TestType.MultipleChoice:
                return GetMultiChoiceKoef(answer, question);
            case TestType.Sequence:
                return 0;
            case TestType.Matching:
                return 0;
            default:
                return 0;
        }
    }

    private double GetTextAnswerKoef(Answer answer, QuestionViewModel question) =>
        answer.TextAnswer == question.CorrectAnswer ? 1 : 0;

    private double GetSingleChoiceKoef(Answer answer, QuestionViewModel question)
    {
        return answer.SelectedOptions.FirstOrDefault().TestOptionId == question.TestOptions.Single(x => x.IsCorrect).Id ? 1 : 0;
    }

    private double GetMultiChoiceKoef(Answer answer, QuestionViewModel question)
    {
        var expectedAnswers = question.TestOptions.Where(x => x.IsCorrect).Select(x => x.Id).ToList();
        var givenAnswers = answer.SelectedOptions.Select(x => x.TestOptionId).ToList();

        var correctAnswersCount = givenAnswers.Count(answer => expectedAnswers.Contains(answer));
        var expectedAnswersCount = expectedAnswers.Count;
        var givenAnswersCount = givenAnswers.Count;
        var allAnswersCount = question.TestOptions.Count;

        if (correctAnswersCount == 0) return 0;
        if (givenAnswersCount == allAnswersCount) return 0.05;
        if (expectedAnswersCount == correctAnswersCount && givenAnswersCount == expectedAnswersCount) return 1;

        return (double)correctAnswersCount / (expectedAnswersCount + givenAnswersCount - correctAnswersCount);
    }


    private int CalculateSummaryScore(int maxScore, int maxKoef, double userKoef)
    {
        return (int)Math.Round(userKoef * maxScore / maxKoef);
    }
}
