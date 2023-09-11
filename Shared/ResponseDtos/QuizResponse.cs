namespace QuizWebApp.Shared.ResponseDtos
{
    public class QuizResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int NumberOfQuestions { get; set; }
        public bool IsFavorite { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
