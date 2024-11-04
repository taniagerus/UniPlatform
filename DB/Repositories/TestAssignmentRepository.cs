using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using UniPlatform.DB.Entities;

namespace UniPlatform.DB.Repositories
{
    public class TestAssignmentRepository : ITestAssignmentRepository
    {
        PlatformDbContext _dbContext;

        public TestAssignmentRepository(PlatformDbContext context)
        {
            _dbContext = context;
        }

        public async Task<TestAssignment> GetTestByIdAsync(int id)
        {
            return await _dbContext
                .TestAssignments.Include(t => t.Answers)
                .ThenInclude(a => a.SelectedOptions)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
