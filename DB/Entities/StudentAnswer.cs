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
        public int Id { get; set; }

        [ForeignKey("TestAttempt")]
        public int TestAttemptId { get; set; }
        public virtual TestAttempt TestAttempt { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual TestQuestion Question { get; set; }

        public virtual ICollection<TestOption> SelectedOptions { get; set; } = new List<TestOption>();// для MultipleChoice
        public string? TextAnswer { get; set; }  // для TextAnswer
        public decimal? Points { get; set; }
    }
}
