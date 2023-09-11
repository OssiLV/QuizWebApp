namespace QuizWebApp.Server.Data.Entities
{
    public class Question
    {
        public Guid Id { get; set; } // primary key
        public string Content { get; set; }
        public string Answer { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Reference Quiz Table
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; } // navigation property
    }
}
