using AutoMapper;
using QuizWebApp.Server.Data.Entities;
using QuizWebApp.Shared.RequestDtos;
using QuizWebApp.Shared.ResponseDtos;

namespace QuizWebApp.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // User to User response object
            CreateMap<User, UserResponse>();

            // SignUpDto to IdentityUser
            CreateMap<RegisterRequest, User>();
            /*.ForMember(dest => dest.PasswordHash, opt => opt.Ignore());*/


            // QuizCreate to Quiz
            CreateMap<QuizCreateRequest, Quiz>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.Now));

            // QuestionCreate to Question
            CreateMap<QuestionCreateRequest, Question>();
        }
    }
}
