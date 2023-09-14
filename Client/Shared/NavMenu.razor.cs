using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using QuizWebApp.Client.Authentication;
using QuizWebApp.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace QuizWebApp.Client.Shared
{
    public partial class NavMenu
    {
        public List<QuizResponse> quizzes { get; set; }
        public List<QuizResponse> favoriteQuizzes { get; set; }
        public List<QuizResponse> trashQuizzes { get; set; }

        [Inject]
        AuthenticationStateProvider _authStateProvider { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }
        [Inject]
        HttpClient _httpClient { get; set; }

        public bool isOpenMenu { get; set; }
        private bool isOpenLibrary { get; set; }
        private bool isOpenAvartar { get; set; }
        private UserResponse user { set; get; }

        protected override async Task OnInitializedAsync()
        {
            var customAuthStateProvider = (CustomAuthenticationStateProvider)_authStateProvider;
            user = await customAuthStateProvider.GetUserAsync();
        }
        async Task ActivateTab( int index )
        {
            var customAuthStateProvider = (CustomAuthenticationStateProvider)_authStateProvider;
            var token = await customAuthStateProvider.GetToken();
            if(index == 0)
            {
                if(!string.IsNullOrEmpty(token))
                {

                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
                    ResponseObjectDto<List<QuizResponse>> response = await _httpClient.GetFromJsonAsync<ResponseObjectDto<List<QuizResponse>>>($"/api/Quiz/{user.Id}/5");
                    quizzes = response.result;
                }
                /* else
                 {
                     _navigationManager.NavigateTo("/login");
                 }*/
                return;
            }

            if(index == 1)
            {
                if(!string.IsNullOrEmpty(token))
                {

                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
                    ResponseObjectDto<List<QuizResponse>> response = await _httpClient.GetFromJsonAsync<ResponseObjectDto<List<QuizResponse>>>($"/api/Quiz/favorite/{user.Id}/5");
                    favoriteQuizzes = response.result;
                }
                /*else
                {
                    _navigationManager.NavigateTo("/login");
                }*/
                return;
            }

            if(index == 2)
            {
                if(!string.IsNullOrEmpty(token))
                {

                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
                    ResponseObjectDto<List<QuizResponse>> response = await _httpClient.GetFromJsonAsync<ResponseObjectDto<List<QuizResponse>>>($"/api/Quiz/trash/{user.Id}/5");
                    trashQuizzes = response.result;
                }
                /* else
                 {
                     _navigationManager.NavigateTo("/login");
                 }*/
                return;
            }
        }
        private async Task HandleChangeStateLibrary()
        {
            isOpenLibrary = !isOpenLibrary;
            if(isOpenLibrary)
            {
                var customAuthStateProvider = (CustomAuthenticationStateProvider)_authStateProvider;
                var token = await customAuthStateProvider.GetToken();
                if(!string.IsNullOrEmpty(token))
                {

                    _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
                    ResponseObjectDto<List<QuizResponse>> response = await _httpClient.GetFromJsonAsync<ResponseObjectDto<List<QuizResponse>>>($"/api/Quiz/{user.Id}/5");
                    quizzes = response.result;
                }
                /*else
                {
                    _navigationManager.NavigateTo("/login");
                }*/
            }
        }

        private void HandleChangeStateAvatar()
        {
            isOpenAvartar = !isOpenAvartar;
        }

        private void NavigateToCreateQuiz()
        {
            _navigationManager.NavigateTo("/create-quiz");
        }

        private void NavigateToHome()
        {
            _navigationManager.NavigateTo("/");
        }

        private void NavigateToProfile()
        {
            _navigationManager.NavigateTo("/profile");
        }
        private async Task Logout()
        {
            var customAuthStateProvider = (CustomAuthenticationStateProvider)_authStateProvider;
            await customAuthStateProvider.UpdateAuthenticationState(null);
            _navigationManager.NavigateTo("/", true);
        }
    }
}
