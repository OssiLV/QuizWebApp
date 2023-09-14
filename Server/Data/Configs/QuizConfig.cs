using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizWebApp.Server.Data.Entities;

namespace QuizWebApp.Server.Data.Configs
{
    public class QuizConfig : IEntityTypeConfiguration<Quiz>
    {
        void IEntityTypeConfiguration<Quiz>.Configure( EntityTypeBuilder<Quiz> builder )
        {
            builder.HasAnnotation("Relational:TableName", "Quizzes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.Description).HasColumnType("nvarchar(max)");

            //For User Table
            builder.HasOne(x => x.User).WithMany(x => x.Quizzes).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
