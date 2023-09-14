namespace QuizWebApp.Server.Data.Entities
{
    public class Quiz
    {
        public Guid Id { get; set; } // primary key
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsFavorite { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //Reference User Table
        public Guid UserId { get; set; }
        public User User { get; set; } // navigation property

        //Reference Question Table
        public List<Question> questions { get; set; } // collection navigation property

        //Reference QuizTag Table
        public List<QuizTag> QuizTags { get; set; } // collection navigation property


    }
}
