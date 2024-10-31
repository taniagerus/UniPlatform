namespace UniPlatform.DB.Entities
{
    public class SelectedOptions
    {
        public int Id {  get; set; }
        public int QuestionId {  get; set; }
        public virtual Question Question { get; set; }
        public int TestOptionId { get; set; }
        public virtual TestOption Option { get; set; }

    }
}
