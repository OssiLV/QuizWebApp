namespace QuizWebApp.Server.Data.Entities
{
    public class QuizTag
    {
        public Guid QuizId { get; set; } // foreign key to Quiz table
        public Guid TagId { get; set; } // foreign key to Tag table

        public Quiz Quiz { get; set; } // navigation property
        public Tag Tag { get; set; } // navigation property
    }
}
