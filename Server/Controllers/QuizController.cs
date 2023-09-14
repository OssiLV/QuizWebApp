using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizWebApp.Server.Services.QuizService;
using QuizWebApp.Shared.RequestDtos;

namespace QuizWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User, Admin")]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController( IQuizService quizService )
        {
            _quizService = quizService;
        }


        [HttpGet]
        [Route("{id}/{item}")]
        public async Task<IActionResult> GetQuizzes( Guid id, int item )
        {
            var response = await _quizService.GetQuizAsync(id, item);

            return StatusCode(response.status, response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAllQuizzes( Guid id )
        {
            var response = await _quizService.GetQuizAsync(id);

            return StatusCode(response.status, response);
        }


        // Favorite
        [HttpGet]
        [Route("favorite/{id}/{item}")]
        public async Task<IActionResult> GetFavoriteQuizzes( Guid id, int item )
        {
            var response = await _quizService.GetFavoriteQuizAsync(id, item);

            return StatusCode(response.status, response);
        }

        // Trash
        [HttpGet]
        [Route("trash/{id}/{item}")]
        public async Task<IActionResult> GetTrashQuizzes( Guid id, int item )
        {
            var response = await _quizService.GetTrashQuizAsync(id, item);

            return StatusCode(response.status, response);
        }









        [HttpPost]
        public async Task<IActionResult> CreateQuizAndQuestion( QuizCreateRequest quizCreateRequest )
        {
            var response = await _quizService.CreateQuizAsync(quizCreateRequest);

            return StatusCode(response.status, response);
        }
    }
}
