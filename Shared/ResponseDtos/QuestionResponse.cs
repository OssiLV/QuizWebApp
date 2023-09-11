namespace QuizWebApp.Shared.ResponseDtos
{
    public class QuestionResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Answer { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
