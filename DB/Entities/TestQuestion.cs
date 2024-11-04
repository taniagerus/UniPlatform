namespace UniPlatform.DB.Entities
{
    public class TestQuestion
    {
        public int Id { get; set; }
        public int TestAssignmentId { get; set; }
        public int QuestionId { get; set; }
        public virtual TestAssignment TestAssignment { get; set; }
        public virtual Question Question { get; set; }
    }
}
