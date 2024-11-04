namespace UniPlatform.ViewModels
{
    public class TestToCheckViewModel
    {
        public int TestAssignmentId { get; set; }
        public int StudentId { get; set; }
        public List<AnswerViewModel> Answers { get; set; }
    }

    public class AnswerViewModel
    {
        public int QuestionId { get; set; }
        public string? TextAnswer { get; set; }
        public List<SelectedOptionViewModel> SelectedOptions { get; set; }
    }
}
