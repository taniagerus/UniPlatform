using System.Text.RegularExpressions;
using UniPlatform.DB.Entities;

namespace UniPlatform.DB.Entities
{
    // Клас для курсів
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int LecturerId { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
        public virtual ICollection<CourseGroup> CourseGroups { get; set; }

        public Course()
        {
            CourseStudents = new List<CourseStudent>();
            CourseGroups = new List<CourseGroup>();
        }
    }

}
