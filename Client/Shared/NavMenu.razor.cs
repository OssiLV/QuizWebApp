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
        AuthenticationStateProvider authStateProvider { get; set; }

        [Inject]
        NavigationManager navigationManager { get; set; }
        private bool isOpenLibrary { get; set; }
        private bool isOpenAvartar { get; set; }
        private string searchValue { get; set; }
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
            navigationManager.NavigateTo("/create-quiz");
        }

        private void NavigateToHome()
        {
            navigationManager.NavigateTo("/");
        }

        private void NavigateToProfile()
        {
            navigationManager.NavigateTo("/profile");
        }
        private async Task Logout()
        {
            var customAuthStateProvider = (CustomAuthenticationStateProvider)authStateProvider;
            await customAuthStateProvider.UpdateAuthenticationState(null);
            navigationManager.NavigateTo("/", true);
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
