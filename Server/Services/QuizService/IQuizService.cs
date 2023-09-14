using QuizWebApp.Shared.RequestDtos;
using QuizWebApp.Shared.ResponseDtos;

namespace QuizWebApp.Server.Services.QuizService
{
    public interface IQuizService
    {
        Task<ResponseObjectDto<object>> CreateQuizAsync( QuizCreateRequest quizCreateRequest );
        Task<ResponseObjectDto<List<QuizResponse>>> GetQuizAsync( Guid id, int item );
        Task<ResponseObjectDto<List<QuizResponse>>> GetQuizAsync( Guid id );
        Task<ResponseObjectDto<List<QuizResponse>>> GetFavoriteQuizAsync( Guid id, int item );
        Task<ResponseObjectDto<List<QuizResponse>>> GetFavoriteQuizAsync( Guid id );
        Task<ResponseObjectDto<List<QuizResponse>>> GetTrashQuizAsync( Guid id, int item );
        Task<ResponseObjectDto<List<QuizResponse>>> GetTrashQuizAsync( Guid id );
        /*Task<ResponseObjectDto> DeleteQuizAsync( Guid Id );*/
    }
}
