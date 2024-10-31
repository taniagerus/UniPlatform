using UniPlatform.DB.Entities;

namespace UniPlatform.ViewModels
{
    public class CreateTestAssignmentRequest
    { 
        public string Title { get; set; }

        public int StudentId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TimeLimit { get; set; }
        public string Category { get; set; }
        public int NumberOfQuestions { get; set; }
    }


    public class TestAssignmentViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int StudentId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TimeLimit { get; set; }
        public string Category { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<QuestionViewModel> Questions { get; set; } = new List<QuestionViewModel>();
    }
}
