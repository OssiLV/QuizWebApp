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

        [HttpPost]
        public async Task<IActionResult> CreateQuizAndQuestion( QuizCreateRequest quizCreateRequest )
        {
            var response = await _quizService.CreateQuizAsync(quizCreateRequest);

            return StatusCode(response.status, response);
        }
    }
}
