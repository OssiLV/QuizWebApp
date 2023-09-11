using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizWebApp.Server.Data.Entities;

namespace QuizWebApp.Server.Data.Configs
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        void IEntityTypeConfiguration<User>.Configure( EntityTypeBuilder<User> builder )
        {
            builder.HasAnnotation("Relational:TableName", "Users");
            builder.HasKey(x => x.Id);
        }
    }
}
