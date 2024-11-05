using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniPlatform.DB.Entities
{
    public class TestOption
    {
        public TestOption() { }

        [Key]
        public int Id { get; set; }

        [Required]
        public string OptionText { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public bool IsCorrect { get; set; } 
        public int? CorrectOrder { get; set; } 
        public string? MatchingPair { get; set; } 
    }
}
