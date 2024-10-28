
using UniPlatform.Models;

namespace UniPlatform.DB.Entities
{
    public class CourseGroup
    {
        public CourseGroup()
        {
            
        }
        public int Id {  get; set; }
        public int CourseId { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual Course Course { get; set; }
    }
}
