namespace QuizWebApp.Server.Services.QuizService
{
    public class QuizService : IQuizService
    {
        /* private readonly QuizAppDbContext _quizAppDbContext;
         private readonly IMapper _mapper;

         public QuizService( QuizAppDbContext quizAppDbContext, IMapper mapper )
         {
             _quizAppDbContext = quizAppDbContext;
             _mapper = mapper;
         }

         public async Task<ResponseObjectDto> CreateQuizAsync( QuizCreateDto quizCreateDto )
         {
             try
             {
                 Quiz newQuiz = _mapper.Map<Quiz>(quizCreateDto);
                 await _quizAppDbContext.Quizzes.AddAsync(newQuiz);

                 await _quizAppDbContext.SaveChangesAsync();

                 return new ResponseObjectDto(StatusCodes.Status201Created, "Created a new Quiz", _mapper.Map<QuizResponseDto>(newQuiz));
             }
             catch(Exception ex)
             {
                 return new ResponseObjectDto(StatusCodes.Status500InternalServerError, ex.Message);
             }
         }

         async Task<ResponseObjectDto> IQuizService.DeleteQuizAsync( Guid Id )
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
