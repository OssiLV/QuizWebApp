using QuizWebApp.Server.Services.QuizService;
using QuizWebApp.Server.Services.TagService;
using QuizWebApp.Server.Services.UserService.AuthService;

namespace QuizWebApp.Server.Configurations
{
    public static class ApplicationSetup
    {
        public static IServiceCollection AddApplicationSetup( this IServiceCollection services )
        {
            // Life Cycle Services
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IQuizService, QuizService>();
            services.AddTransient<ITagService, TagService>();

            /*services.AddSingleton<UserAccountService>();*/

            // Config AutoMapping
            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
