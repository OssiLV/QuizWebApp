using AutoMapper;
using QuizWebApp.Server.Data.Context;
using QuizWebApp.Server.Data.Entities;
using QuizWebApp.Shared.RequestDtos;
using QuizWebApp.Shared.ResponseDtos;

namespace QuizWebApp.Server.Services.QuizService
{
    public class QuizService : IQuizService
    {
        private readonly QuizAppDbContext _quizAppDbContext;
        private readonly IMapper _mapper;

        public QuizService( QuizAppDbContext quizAppDbContext, IMapper mapper )
        {
            _quizAppDbContext = quizAppDbContext;
            _mapper = mapper;
        }
        public async Task<ResponseObjectDto<object>> CreateQuizAsync( QuizCreateRequest quizCreateRequest )
        {
            try
            {
                await _quizAppDbContext.Quizzes.AddAsync(_mapper.Map<Quiz>(quizCreateRequest));
                await _quizAppDbContext.Questions.AddRangeAsync(_mapper.Map<List<Question>>(quizCreateRequest.questionCreateRequests));
                await _quizAppDbContext.SaveChangesAsync();
                return new ResponseObjectDto<object>(StatusCodes.Status201Created, "Created Quiz and Question", null);
            }
            catch(Exception ex)
            {
                return new ResponseObjectDto<object>(StatusCodes.Status500InternalServerError, ex.Message, null);
            }
        }

        /*async Task<ResponseObjectDto> IQuizService.DeleteQuizAsync( Guid Id )
        {
            try
            {
                var currentQuiz = await _quizAppDbContext.Quizzes.FindAsync(Id);
                if(currentQuiz is null)
                    return new ResponseObjectDto(StatusCodes.Status404NotFound, $"Cannot find Quiz with this Id: {Id}");

                _quizAppDbContext.Quizzes.Remove(currentQuiz);

                await _quizAppDbContext.SaveChangesAsync();

                return new ResponseObjectDto(StatusCodes.Status200OK, $"Deleted Quiz with this Id: {Id}");
            }
            catch(Exception ex)
            {
                return new ResponseObjectDto(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }*/

    }
}
