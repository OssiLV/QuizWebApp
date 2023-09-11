using Microsoft.AspNetCore.Identity;
using QuizWebApp.Server.Data.Context;
using QuizWebApp.Server.Data.Entities;

namespace QuizWebApp.Server.Configurations
{
    public static class IdentitySetup
    {
        public static IServiceCollection AddIdentitySetup( this IServiceCollection services )
        {
            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<QuizAppDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 4;
            });

            return services;
        }
    }
}
