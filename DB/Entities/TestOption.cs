using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniPlatform.DB.Entities
{
    public class TestOption
    {
        public TestOption()
        {
            
        }
        [Key]
        public string Id { get; set; }

        [Required]
        public string OptionText { get; set; }

        [ForeignKey("Question")]
        public string QuestionId { get; set; }
        public virtual TestQuestion Question { get; set; }

        public bool IsCorrect { get; set; }  // для SingleChoice
        public int? CorrectOrder { get; set; }  // для Sequence
        public string? MatchingPair { get; set; }  // для Matching
    }
}
