using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using QuizWebApp.Client.Authentication;
using QuizWebApp.Shared.RequestDtos;
using QuizWebApp.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace QuizWebApp.Client.Components.Auth
{
    public partial class LoginComponent
    {
        [Parameter]
        public required Action ChangeLoginAndRegisterPage { set; get; }

        [Inject]
        HttpClient httpClient { set; get; }

        [Inject]
        IJSRuntime js { set; get; }

        /*[Inject]
        HttpClient httpClient { set; get; }*/

        [Inject]
        AuthenticationStateProvider authStateProvider { set; get; }

        [Inject]
        NavigationManager navigation { set; get; }

        private LoginRequest loginRequest = new LoginRequest();

        public void Test()
        {
            Console.WriteLine("Login: " + new { loginRequest.UserNameOrEmail, loginRequest.Password });
        }

        public async Task LoginHandler()
        {
            var loginResponse = await httpClient.PostAsJsonAsync<LoginRequest>("/api/Account/Login", loginRequest);

            await Console.Out.WriteLineAsync(loginResponse.StatusCode.ToString());
            if(loginResponse.IsSuccessStatusCode)
            {
                var userSession = await loginResponse.Content.ReadFromJsonAsync<ResponseObjectDto<UserResponse>>();
                var customAuthStateProvider = (CustomAuthenticationStateProvider)authStateProvider;
                await customAuthStateProvider.UpdateAuthenticationState(userSession.result);
                navigation.NavigateTo("/", true);
            }
            else if(loginResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await js.InvokeVoidAsync("alert", "Invalid User Name or Password");
                return;
            }
        }
    }
}
