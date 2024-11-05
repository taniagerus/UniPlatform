using Microsoft.EntityFrameworkCore;
using UniPlatform.DB.Entities;

namespace UniPlatform.DB.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        PlatformDbContext _context;

        public QuestionRepository(PlatformDbContext context)
        {
            _context = context;
        }

        public async Task<int> GetQuestionsCountByCategoryAsync(          string category      )
        {
            return await _context
                .Questions.CountAsync(e => e.Category == category);                
        }


        public async Task<IEnumerable<Question>> GetRandomTestQuestionsAsync(
            string category,
            int numberOfQuestions
        )
        {
            return await _context
                .Questions.Where(e => e.Category == category)
                .OrderBy(x => Guid.NewGuid())
                .Take(numberOfQuestions)
                .ToListAsync();
        }
    }
}
//public List<Question> GetRandomTestQuestionsForAssignment(
//       string category,
//       int numberOfQuestions
//   )
//{
//    return _context
//        .Questions.Where(e => e.Category == category)
//        .OrderBy(x => Guid.NewGuid())
//        .Take(numberOfQuestions)
//        //.AsNoTracking()
//        .ToList();
//}
