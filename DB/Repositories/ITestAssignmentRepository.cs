using Microsoft.EntityFrameworkCore;
using UniPlatform.DB.Entities;

namespace UniPlatform.DB.Repositories
{
    public interface ITestAssignmentRepository
    {
        public Task<TestAssignment> GetTestByIdAsync(int id);
    }
}
//var test = await _context
//               .TestAssignments.Include(t => t.Answers)
//               .ThenInclude(a => a.SelectedOptions)
//               .FirstOrDefaultAsync(t => t.Id == id);
