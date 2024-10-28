using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniPlatform.DB.Entities
{
    public class TestQuestion
    {
        public TestQuestion()
        {
            
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string QuestionText { get; set; }

        public TestType Type { get; set; }
        public DifficultyLevel Difficulty { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual TestCategory Category { get; set; }

        public virtual ICollection<TestOption> Options { get; set; } = new List<TestOption>();
        public virtual ICollection<TestAssignment> TestAssignments { get; set; } = new List<TestAssignment>();
    }
}
