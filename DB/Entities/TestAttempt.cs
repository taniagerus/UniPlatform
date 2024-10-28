using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniPlatform.DB.Entities
{
    public class TestAttempt
    {
        public TestAttempt()
        {
            
        }
        [Key]
        public int Id { get; set; }

        [ForeignKey("TestAssignment")]
        public int TestAssignmentId { get; set; }
        public virtual TestAssignment TestAssignment { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? Score { get; set; }

        public virtual ICollection<StudentAnswer> Answers { get; set; } = new List<StudentAnswer>();
    }

}
