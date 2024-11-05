using System.ComponentModel.DataAnnotations;

namespace UniPlatform.DB.Entities
{
    public class Answer
    {
        public Answer() { }

        [Key]
        public int Id { get; set; }
        public int TestAssignmentId { get; set; }
        public virtual TestAssignment TestAssignment { get; set; }
        public int TestAttemptId { get; set; }
        public virtual TestAttempt TestAttempt { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public virtual ICollection<SelectedOption> SelectedOptions { get; set; } = [];
        public string? TextAnswer { get; set; }
        public decimal? Points { get; set; }
    }
}
