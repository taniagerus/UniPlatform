namespace UniPlatform.DB.Entities
{
    public class TestAttempt
    {
        public int Id { get; set; }
        public DateTime SubmittedAt { get; set; }
        public int TestAssignmentId { get; set; }
        public int Score { get; set; }
        public virtual TestAssignment TestAssignment { get; set; }
        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
