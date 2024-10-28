using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniPlatform.DB.Entities
{
    public class TestCategory
    {
        public TestCategory()
        {
            
        }
        [Key]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
        [ForeignKey("Course")]
        public string CourseId { get; set; }
        public virtual Course Course { get; set; }

        public virtual ICollection<TestQuestion> Questions { get; set; } = new List<TestQuestion>();
    }

}
