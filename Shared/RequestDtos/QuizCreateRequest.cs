namespace QuizWebApp.Shared.RequestDtos
{
    public class QuizCreateRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UserId { get; set; }
        public List<QuestionCreateRequest> questionCreateRequests { get; set; }
    }
}
