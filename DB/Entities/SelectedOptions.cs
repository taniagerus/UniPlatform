namespace UniPlatform.DB.Entities
{
    public class SelectedOption
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public int TestOptionId { get; set; }
        public virtual TestOption TestOption { get; set; }
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
