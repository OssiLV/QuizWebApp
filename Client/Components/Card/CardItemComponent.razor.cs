using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using QuizWebApp.Client.Authentication;
using QuizWebApp.Shared.ResponseDtos;

namespace QuizWebApp.Client.Components.Card
{
    public partial class CardItemComponent
    {
        [Parameter]
        public QuizResponse Quiz { get; set; }
        [Inject]
        AuthenticationStateProvider _authStateProvider { get; set; }
        private UserResponse user { set; get; }
        protected override async Task OnInitializedAsync()
        {
            var customAuthStateProvider = (CustomAuthenticationStateProvider)_authStateProvider;
            user = await customAuthStateProvider.GetUserAsync();
        }
    }
}
