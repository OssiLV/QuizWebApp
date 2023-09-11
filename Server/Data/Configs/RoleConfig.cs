using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizWebApp.Server.Data.Entities;

namespace QuizWebApp.Server.Data.Configs
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        void IEntityTypeConfiguration<Role>.Configure( EntityTypeBuilder<Role> builder )
        {
            builder.HasAnnotation("Relational:TableName", "Roles");
            builder.HasKey(x => x.Id);

            builder.HasData(
                new Role { Id = Guid.NewGuid(), Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new Role { Id = Guid.NewGuid(), Name = "User", ConcurrencyStamp = "2", NormalizedName = "USER" }
                );


        }
    }
}
