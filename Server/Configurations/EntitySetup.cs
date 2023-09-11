using Microsoft.EntityFrameworkCore;
using QuizWebApp.Server.Data.Context;

namespace QuizWebApp.Server.Configurations
{
    public static class EntitySetup
    {
        public static IServiceCollection AddEntitySetup( this IServiceCollection services, IConfiguration configuration )
        {
            services.AddDbContext<QuizAppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("sqlServer")));

            return services;
        }
    }
}