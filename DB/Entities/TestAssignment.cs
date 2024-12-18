﻿using System.ComponentModel.DataAnnotations;

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
        public int? MaxPoints { get; set; }
        public string Categories { get; set; }
        public int NumberOfQuestions { get; set; }
        public virtual ICollection<TestQuestion> Questions { get; set; } = new List<TestQuestion>();
        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
        public virtual ICollection<TestAttempt> TestAttempts { get; set; } =
            new List<TestAttempt>();
    }
}
