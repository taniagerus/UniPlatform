using UniPlatform.Models;

namespace UniPlatform.DB.Entities
{
    public class Department
    {
        public Department()
        {
            
        }

        public string Id { get; set; }
        public string Name { get; set; }
        //public virtual ICollection<Course> Courses { get; set; } = [];
        public virtual ICollection<Lecturer> Lecturers { get; set; } = new List<Lecturer>();
        public virtual ICollection<Assistant> Assistants { get; set; } = new List<Assistant>();
        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
        //public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    }
}
