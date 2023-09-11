using Microsoft.AspNetCore.Components;
using QuizWebApp.Shared.RequestDtos;
using QuizWebApp.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace QuizWebApp.Client.Components.Auth
{
    public partial class RegisterComponent
    {
        [Parameter]
        public EventCallback ChangeLoginAndRegisterPage { set; get; }

        [Inject]
        HttpClient httpClient { set; get; }

        private RegisterRequest registerRequest = new RegisterRequest();
        private string responseMessage { get; set; }

        protected override void OnInitialized()
        {
            registerRequest.Role = "User";
        }

        public async Task TestFunc()
        {
            await ChangeLoginAndRegisterPage.InvokeAsync();

        }

        public async Task SignUpHandler()
        {
            var registerResponse = await httpClient.PostAsJsonAsync<RegisterRequest>("/api/Account/signup", registerRequest);
            if(registerResponse.IsSuccessStatusCode)
            {
                await ChangeLoginAndRegisterPage.InvokeAsync();
            }
            else
            {
                var userSession = await registerResponse.Content.ReadFromJsonAsync<ResponseObjectDto<UserResponse>>();
                responseMessage = userSession.message;
            }
        }
    }
}
