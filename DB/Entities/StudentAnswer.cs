using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniPlatform.DB.Entities
{
    public class StudentAnswer
    {
        public StudentAnswer()
        {
            
        }
        [Key]
        public string Id { get; set; }

        [ForeignKey("TestAttempt")]
        public string TestAttemptId { get; set; }
        public virtual TestAttempt TestAttempt { get; set; }

        [ForeignKey("Question")]
        public string QuestionId { get; set; }
        public virtual TestQuestion Question { get; set; }

        public virtual ICollection<TestOption> SelectedOptions { get; set; } = new List<TestOption>();// для MultipleChoice
        public string? TextAnswer { get; set; }  // для TextAnswer
        public decimal? Points { get; set; }
    }
}
