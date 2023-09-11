using QuizWebApp.Shared.RequestDtos;
using QuizWebApp.Shared.ResponseDtos;

namespace QuizWebApp.Server.Services.UserService.AuthService
{
    public interface IAuthService
    {
        bool IsValidEmail( string email );
        /*JwtSecurityToken GenerateToken( List<Claim> authClaims );*/
        Task<ResponseObjectDto<object>> SignUpAsync( RegisterRequest registerRequest );
        Task<ResponseObjectDto<UserResponse>> LoginAsync( LoginRequest loginRequest );
    }
}
