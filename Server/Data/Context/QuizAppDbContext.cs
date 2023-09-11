using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizWebApp.Server.Data.Configs;
using QuizWebApp.Server.Data.Entities;

namespace QuizWebApp.Server.Data.Context
{
    public class QuizAppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<QuizTag> QuizTags { get; set; }

        public QuizAppDbContext( DbContextOptions options ) : base(options) { }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            builder.ApplyConfiguration(new QuestionConfig());
            builder.ApplyConfiguration(new QuizConfig());
            builder.ApplyConfiguration(new TagConfig());
            builder.ApplyConfiguration(new QuizTagConfig());
            builder.ApplyConfiguration(new RoleConfig());

            builder.Entity<IdentityUserRole<Guid>>(options =>
            {
                options.ToTable("UserRoles").HasKey(x => new { x.UserId, x.RoleId });
            });

            builder.Entity<IdentityUserLogin<Guid>>(options =>
            {
                options.ToTable("UserLogins").HasKey(x => x.UserId);
            });

            builder.Entity<IdentityUserToken<Guid>>(options =>
            {
                options.ToTable("UserTokens").HasKey(x => x.UserId);
            });
        }
    }
}
