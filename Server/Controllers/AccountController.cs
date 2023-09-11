using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizWebApp.Server.Services.UserService.AuthService;
using QuizWebApp.Shared.RequestDtos;

namespace QuizWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController( IAuthService authService )
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login( [FromBody] LoginRequest loginRequest )
        {
            /*var jwtAuthenticationManager = new JwtAuthenticationManager(_userAccountService);
            var userSession = jwtAuthenticationManager.GenerateJwtToken(loginRequest.UserNameOrEmail, loginRequest.Password);*/
            var userSession = await _authService.LoginAsync(loginRequest);
            return StatusCode(userSession.status, userSession);
            /*if(userSession is null)
            else
                return userSession;*/
        }
        /* public ActionResult<ResponseObjectDto<UserResponse>> Login( [FromBody] LoginRequest loginRequest )
         {
             *//*var jwtAuthenticationManager = new JwtAuthenticationManager(_userAccountService);
             var userSession = jwtAuthenticationManager.GenerateJwtToken(loginRequest.UserNameOrEmail, loginRequest.Password);*//*
             var userSession = _authService.LoginAsync(loginRequest);
             if(userSession is null)
                 return Unauthorized();
             else
                 return userSession;
         }*/

        [HttpPost]
        [Route("signup")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp( [FromBody] RegisterRequest registerRequest )
        {
            /*var jwtAuthenticationManager = new JwtAuthenticationManager(_userAccountService);
            var userSession = jwtAuthenticationManager.GenerateJwtToken(loginRequest.UserNameOrEmail, loginRequest.Password);*/
            var response = await _authService.SignUpAsync(registerRequest);
            return StatusCode(response.status, response);
            /*if(userSession is null)
            else
                return userSession;*/
        }
    }
}
