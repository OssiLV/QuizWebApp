using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using QuizWebApp.Client.Authentication;
using QuizWebApp.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace QuizWebApp.Client.Pages
{
    public partial class Index
    {
        [Inject]
        AuthenticationStateProvider _authStateProvider { get; set; }

        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Inject]
        HttpClient _httpClient { get; set; }
        private UserResponse user { set; get; }

        List<QuizResponse> listQuizzes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var customAuthStateProvider = (CustomAuthenticationStateProvider)_authStateProvider;
            user = await customAuthStateProvider.GetUserAsync();

            var token = await customAuthStateProvider.GetToken();
            if(!string.IsNullOrEmpty(token))
            {

                _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
                ResponseObjectDto<List<QuizResponse>>? response = await _httpClient.GetFromJsonAsync<ResponseObjectDto<List<QuizResponse>>>($"/api/Quiz/{user.Id}/8");
                if(response?.result is not null)
                {
                    listQuizzes = response.result;
                }
            }
            else
            {
                _navigationManager.NavigateTo("/login");
            }
        }
    }
}
