namespace UniPlatform.DB.Entities
{
    public class CourseStudent
    {
        public CourseStudent()
        {
            
        }
        public int Id {  get; set; } 
        public int StudentId { get; set; }
        public int CourseId {  get; set; }
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}
