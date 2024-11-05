using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniPlatform.DB.Entities
{
    public class Answer
    {
        public Answer() { }

        [Key]
        public int Id { get; set; }
        public int TestAssignmentId { get; set; }
        public virtual TestAssignment TestAssignment { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public virtual ICollection<TestOption> SelectedOptions { get; set; } =
            new List<TestOption>(); 
        public string? TextAnswer { get; set; } 
        public decimal? Points { get; set; }
    }
}
