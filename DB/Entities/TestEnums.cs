namespace UniPlatform.DB.Entities
{
    public enum TestType
    {
        SingleChoice, // 1 з багатьох
        MultipleChoice, // багато з багатьох
        Sequence, // послідовність
        Matching, // відповідність
        TextAnswer // текстова відповідь
        ,
    }

    public enum DifficultyLevel
    {
        Easy = 1,
        Medium = 2,
        Hard = 3,
    }
}
