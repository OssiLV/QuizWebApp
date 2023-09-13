using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using QuizWebApp.Client.Extensions;
using QuizWebApp.Shared.ResponseDtos;
using System.Security.Claims;

namespace QuizWebApp.Client.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ISessionStorageService _sessionStorageService;
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());
        public CustomAuthenticationStateProvider( ISessionStorageService sessionStorageService )
        {
            _sessionStorageService = sessionStorageService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                /*var userSession = await _sessionStorageService.ReadEncryptedItemAsync<UserSession>("UserSession");*/
                var userSession = await _sessionStorageService.ReadEncryptedItemAsync<UserResponse>("UserSession");

                if(userSession is null)
                    return await Task.FromResult(new AuthenticationState(_anonymous));
                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Email, userSession.Email),
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role),
                }, "JwtAuth"));

                return await Task.FromResult(new AuthenticationState(claimsPrincipal));

            }
            catch(Exception ex)
            {
                return await Task.FromResult(new AuthenticationState(_anonymous));
            }
        }

        public async Task UpdateAuthenticationState( UserResponse? userSession )
        {
            ClaimsPrincipal claimsPrincipal;
            if(userSession is not null)
            {
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimTypes.Email, userSession.Email),
                    new Claim(ClaimTypes.Name, userSession.UserName),
                    new Claim(ClaimTypes.Role, userSession.Role),
                }));
                userSession.ExpiryTimeStamp = DateTime.Now.AddSeconds(userSession.ExpiresIn);
                await _sessionStorageService.SaveItemEncryptedAsync("UserSession", userSession);
            }
            else
            {
                claimsPrincipal = _anonymous;
                await _sessionStorageService.RemoveItemAsync("UserSession");
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        public async Task<string> GetToken()
        {
            var resulllt = string.Empty;

            try
            {
                var userSession = await _sessionStorageService.ReadEncryptedItemAsync<UserResponse>("UserSession");
                if(userSession is not null && DateTime.Now < userSession.ExpiryTimeStamp)
                    resulllt = userSession.Token;
            }
            catch { }
            return resulllt;
        }

        public async Task<UserResponse> GetUserAsync()
        {
            UserResponse user = new UserResponse();
            try
            {
                var userSession = await _sessionStorageService.ReadEncryptedItemAsync<UserResponse>("UserSession");
                if(userSession is not null && DateTime.Now < userSession.ExpiryTimeStamp)
                    user = userSession;

            }
            catch { }
            return user;
        }
    }
}
