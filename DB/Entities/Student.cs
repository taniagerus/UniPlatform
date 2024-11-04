namespace UniPlatform.DB.Entities
{
    public class Student : User
    {
        public EducationLevelEnum EducationLevel { get; set; }

        //[ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
        public virtual ICollection<StudentGroup> StudentGroups { get; set; }

        public Student()
        {
            CourseStudents = new List<CourseStudent>();
            StudentGroups = new List<StudentGroup>();
        }
    }
}
