using Microsoft.EntityFrameworkCore;
using UniPlatform.DB.Entities;

namespace UniPlatform.DB.Repositories
{
    public interface IQuestionRepository
    {
        public Task<int> GetQuestionsCountByCategoryAsync(
          string category       );

        public Task<IEnumerable<Question>> GetRandomTestQuestionsAsync(
            string category,
            int numberOfQuestions
        );
    }
}
