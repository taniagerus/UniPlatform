namespace UniPlatform.DB.Entities
{
    public class StudentStream
    {
        public string Id { get; set; }
        public string StreamName { get; set; }
        public EducationLevelEnum EducationLevel { get; set; }
        public virtual ICollection<StudentGroup> StudentGroups { get; set; }

        public StudentStream()
        {
            StudentGroups = new List<StudentGroup>();
        }
    }
}
