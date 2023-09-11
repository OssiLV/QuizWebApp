namespace QuizWebApp.Server.Data.Entities
{
    public class Tag
    {
        public Guid Id { get; set; } // primary key
        public string Name { get; set; }


        //Reference QuizTag Table
        public List<QuizTag> QuizTags { get; set; } // collection navigation property
    }


}
