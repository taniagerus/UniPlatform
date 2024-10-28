using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniPlatform.DB.Entities
{
    public class TestAssignment
    {

        public TestAssignment()
        {
            
        }
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TimeLimit { get; set; }  
        public decimal MaxPoints { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual TestCategory Category { get; set; }
        public int NumberOfQuestions { get; set; }
        public virtual ICollection<TestQuestion> Questions { get; set; }  = new List<TestQuestion>();
        public virtual ICollection<TestAttempt> Attempts { get; set; } = new List<TestAttempt>();
    }

}
