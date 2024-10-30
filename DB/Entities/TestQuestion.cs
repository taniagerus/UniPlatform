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
        //public DifficultyLevel Difficulty { get; set; }

        //[ForeignKey("Category")]
        public string Category { get; set; }
       public string CorrectAnswer { get; set; }
        //public virtual TestCategory Category { get; set; }
public string Options {  get; set; }
        //public virtual ICollection<TestAssignment> TestAssignments { get; set; } = new List<TestAssignment>();
    }
}
