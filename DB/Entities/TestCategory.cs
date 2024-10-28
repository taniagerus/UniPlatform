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
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public virtual ICollection<TestQuestion> Questions { get; set; } = new List<TestQuestion>();
    }

}
