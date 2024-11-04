using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Options;

namespace UniPlatform.DB.Entities
{
    public class Question
    {
        public Question() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public string QuestionText { get; set; }

        public TestType Type { get; set; }

        //public DifficultyLevel Difficulty { get; set; }

        //[ForeignKey("Category")]
        public string Category { get; set; }
        public string CorrectAnswer { get; set; }

        //public virtual TestCategory Category { get; set; }
        public string? Options { get; set; }
        public virtual ICollection<TestOption> TestOptions { get; set; } = new List<TestOption>();
    }
}
