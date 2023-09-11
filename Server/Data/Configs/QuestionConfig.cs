using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizWebApp.Server.Data.Entities;


namespace QuizWebApp.Server.Data.Configs
{
    public class QuestionConfig : IEntityTypeConfiguration<Question>
    {
        void IEntityTypeConfiguration<Question>.Configure( EntityTypeBuilder<Question> builder )
        {
            builder.HasAnnotation("Relational:TableName", "Questions");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Content).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(x => x.Answer).HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}
