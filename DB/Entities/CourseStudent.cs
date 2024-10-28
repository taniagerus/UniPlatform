namespace UniPlatform.DB.Entities
{
    public class CourseStudent
    {
        public CourseStudent()
        {
            
        }
        public string Id {  get; set; } 
        public string StudentId { get; set; }
        public string CourseId {  get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
