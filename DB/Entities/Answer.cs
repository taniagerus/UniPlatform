using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniPlatform.DB.Entities
{
    public class Answer
    {
        public Answer()
        {
            
        }
        [Key]
        public int Id { get; set; }
        public int TestAssignmentId { get; set; }
        public virtual TestAssignment TestAssignment { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public virtual ICollection<TestOption> SelectedOptions { get; set; } = new List<TestOption>();// для MultipleChoice
        public string? TextAnswer { get; set; }  // для TextAnswer
        public decimal? Points { get; set; }
    }
}
