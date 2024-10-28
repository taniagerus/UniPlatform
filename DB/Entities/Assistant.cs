using System.ComponentModel.DataAnnotations.Schema;

namespace UniPlatform.DB.Entities
{
    public class Assistant : User
    {
        public virtual Lecturer Lecturer { get; set; }
        public string LecturerId { get; set; }
        //public virtual ICollection<Course> AssistingCourses { get; set; }
        public string DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public Assistant()
        {
            //AssistingCourses = new List<Course>();
        }
    }
}
