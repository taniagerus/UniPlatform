using UniPlatform.DB.Entities;

namespace UniPlatform.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public TestType Type { get; set; }

        //public DifficultyLevel Difficulty { get; set; }

        //[ForeignKey("Category")]
        public string Category { get; set; }
        public string CorrectAnswer { get; set; }

        //public string[] Options { get; set; }
        //public virtual TestCategory Category { get; set; }

        public List<OptionViewModel> TestOptions { get; set; }
    }
}
