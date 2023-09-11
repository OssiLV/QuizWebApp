using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizWebApp.Server.Data.Entities;
namespace QuizWebApp.Server.Data.Configs
{
    public class TagConfig : IEntityTypeConfiguration<Tag>
    {
        void IEntityTypeConfiguration<Tag>.Configure( EntityTypeBuilder<Tag> builder )
        {
            builder.HasAnnotation("Relational:TableName", "Tags");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("nvarchar(max)").IsRequired();

            builder.HasData(
                new Tag { Id = Guid.NewGuid(), Name = "Easy" },
                new Tag { Id = Guid.NewGuid(), Name = "Medium" },
                new Tag { Id = Guid.NewGuid(), Name = "Hard" }
                );
        }
    }
}
