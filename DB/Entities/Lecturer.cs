using System.ComponentModel.DataAnnotations.Schema;

namespace UniPlatform.DB.Entities
{
    // Клас для лекторів
    public class Lecturer : User
    {
        //public virtual ICollection<Course> AssignedCourses { get; set; }
        public virtual ICollection<Assistant> Assistants { get; set; }
        public string DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public Lecturer()
        {
            //AssignedCourses = new List<Course>();
            Assistants = new List<Assistant>();
        }
    }
}
