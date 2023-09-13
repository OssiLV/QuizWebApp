using QuizWebApp.Shared.RequestDtos;
using QuizWebApp.Shared.ResponseDtos;

namespace QuizWebApp.Server.Services.QuizService
{
    public interface IQuizService
    {
        Task<ResponseObjectDto<object>> CreateQuizAsync( QuizCreateRequest quizCreateRequest );
        /*Task<ResponseObjectDto> DeleteQuizAsync( Guid Id );*/
    }
}
