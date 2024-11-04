using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniPlatform.ViewModels;

namespace UniPlatform.DB.Entities
{
    public class TestAssignment
    {
        public TestAssignment() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int StudentId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TimeLimit { get; set; }
        public decimal? MaxPoints { get; set; }
        public string Categories { get; set; }
        public int NumberOfQuestions { get; set; }
        public virtual ICollection<TestQuestion> Questions { get; set; } = new List<TestQuestion>();
        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
