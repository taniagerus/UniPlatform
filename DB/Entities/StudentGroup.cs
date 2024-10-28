using UniPlatform.Models;

namespace UniPlatform.DB.Entities
{
    public class StudentGroup
    {
        public StudentGroup()
        {
            
        }
        public int Id { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; }
    }
}
