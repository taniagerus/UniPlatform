//using System;
//using System.Linq;
//using UniPlatform.Models;
//using UniPlatform.Models.TestModels; 

//public class TestService
//{
//	private readonly PlatformDbContext _context;

//	public TestService(PlatformDbContext context)
//	{
//		_context = context;
//	}

//	// Додавання нової категорії тесту
//	public void AddTestCategory(string name, string description, int courseId)
//	{
//		var category = new TestCategory
//		{
//			Name = name,
//			CourseId = courseId
//		};

//		_context.TestCategories.Add(category);
//		_context.SaveChanges();
//	}

//	// Додавання нового питання в категорію
//	public void AddTestQuestion(string questionText, TestType type, DifficultyLevel difficulty, int categoryId)
//	{
//		var question = new TestQuestion
//		{
//			QuestionText = questionText,
//			Type = type,
//			Difficulty = difficulty,
//			CategoryId = categoryId
//		};

//		_context.TestQuestions.Add(question);
//		_context.SaveChanges();
//	}

//	// Додавання нового варіанту відповіді
//	public void AddTestOption(string optionText, int questionId, bool isCorrect = false, int? correctOrder = null, string matchingPair = null)
//	{
//		var option = new TestOption
//		{
//			OptionText = optionText,
//			QuestionId = questionId,
//			IsCorrect = isCorrect,
//			CorrectOrder = correctOrder,
//			MatchingPair = matchingPair
//		};

//		_context.TestOptions.Add(option);
//		_context.SaveChanges();
//	}
//}
