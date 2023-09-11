using Microsoft.AspNetCore.Identity;

namespace QuizWebApp.Server.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        //Reference Quiz Table
        public List<Quiz> Quizzes { get; set; } // collection navigation property

    }
}
