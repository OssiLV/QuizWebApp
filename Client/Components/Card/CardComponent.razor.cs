using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using QuizWebApp.Client.Authentication;
using QuizWebApp.Shared.ResponseDtos;

namespace QuizWebApp.Client.Components.Card
{
    public partial class CardComponent
    {
        [Inject]
        AuthenticationStateProvider _authStateProvider { get; set; }

        [Inject]
        NavigationManager _navigationManager { get; set; }
        private UserResponse user { set; get; }

        protected override async Task OnInitializedAsync()
        {
            var customAuthStateProvider = (CustomAuthenticationStateProvider)_authStateProvider;
            user = await customAuthStateProvider.GetUserAsync();
        }
    }
}
