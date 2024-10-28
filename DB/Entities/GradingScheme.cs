using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using UniPlatform.DB.Entities;

namespace UniPlatform.Models.TestModels
{
    public class GradingScheme
    {
        public GradingScheme()
        {
            
        }

        [Key]
        public string Id { get; set; }

        [ForeignKey("Course")]
        public string CourseId { get; set; }
        public virtual Course Course { get; set; }

        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        public virtual TestCategory Category { get; set; }

        public DifficultyLevel Difficulty { get; set; }
        public decimal PointsPerQuestion { get; set; }
        public decimal? PartialCreditPercentage { get; set; }  // для MultipleChoice
        public decimal? PenaltyPercentage { get; set; }  // штраф за неправильну відповідь
    }
}
