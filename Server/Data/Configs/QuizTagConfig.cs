using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizWebApp.Server.Data.Entities;

namespace QuizWebApp.Server.Data.Configs
{
    public class QuizTagConfig : IEntityTypeConfiguration<QuizTag>
    {
        void IEntityTypeConfiguration<QuizTag>.Configure( EntityTypeBuilder<QuizTag> builder )
        {
            builder.HasAnnotation("Relational:TableName", "QuizTags");
            builder.HasKey(x => new { x.QuizId, x.TagId });

            builder.HasOne(x => x.Quiz).WithMany(x => x.QuizTags).HasForeignKey(x => x.QuizId);
            builder.HasOne(x => x.Tag).WithMany(x => x.QuizTags).HasForeignKey(x => x.TagId);
        }
    }
}
