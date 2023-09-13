using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using QuizWebApp.Client.Authentication;
using QuizWebApp.Shared.ResponseDtos;

namespace QuizWebApp.Client.Shared
{
    public partial class NavMenu
    {
        [Parameter]
        public List<QuizResponse> Quizzes { get; set; }

        [Inject]
        AuthenticationStateProvider _authStateProvider { get; set; }

        [Inject]
        NavigationManager _navigationManager { get; set; }
        private bool isOpenLibrary { get; set; }
        private bool isOpenAvartar { get; set; }
        private string searchValue { get; set; }
        private UserResponse user { set; get; }

        protected override async Task OnInitializedAsync()
        {
            var customAuthStateProvider = (CustomAuthenticationStateProvider)_authStateProvider;
            user = await customAuthStateProvider.GetUserAsync();
        }
        private void HandleChangeStateLibrary()
        {
            isOpenLibrary = !isOpenLibrary;
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
        private const string test = "vohoanganhtruong@gmail.com";

        private string ConvertToShortString( string value )
        {
            if(string.IsNullOrEmpty(value))
            {
                return "Undefined";
            }

            if(value.Length > 17)
            {
                return value.Substring(0, 17) + "...";
            }

            return value;
        }
    }
}
