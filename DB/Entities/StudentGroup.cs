using UniPlatform.Models;

namespace UniPlatform.DB.Entities
{
    public class StudentGroup
    {
        public StudentGroup()
        {
            
        }
        public string Id { get; set; }

        public string StudentId { get; set; }
        public virtual Student Student { get; set; }

        public string GroupId { get; set; }
        public virtual Group Group { get; set; }

        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; }
    }
}
