using UniPlatform.DB.Entities;

namespace UniPlatform.Models
{
    // Клас для навчальних груп
    public class Group
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string DepartmentId { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<StudentGroup> StudentGroups { get; set; }
        public virtual ICollection<CourseGroup> CourseGroup { get; set; }

        public Group()
        {
            StudentGroups = new List<StudentGroup>();
            CourseGroup = new List<CourseGroup>();
        }
    }
}
