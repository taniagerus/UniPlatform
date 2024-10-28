
using UniPlatform.Models;

namespace UniPlatform.DB.Entities
{
    public class CourseGroup
    {
        public CourseGroup()
        {
            
        }
        public string Id {  get; set; }
        public string CourseId { get; set; }
        public string GroupId { get; set; }
        public virtual Group Group { get; set; }
        public virtual Course Course { get; set; }
    }
}
