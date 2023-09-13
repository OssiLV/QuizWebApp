using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using QuizWebApp.Client.Authentication;
using QuizWebApp.Shared.ResponseDtos;

namespace QuizWebApp.Client.Pages
{
    public partial class Index
    {
        [Inject]
        AuthenticationStateProvider _authStateProvider { get; set; }

        [Inject]
        NavigationManager _navigationManager { get; set; }
        private UserResponse user { set; get; }

        List<QuizResponse> listQuiz = new List<QuizResponse>
        {
            new QuizResponse{Id = Guid.NewGuid(), NumberOfQuestions = 2, Title = "Title_1", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsFavorite = true},
            new QuizResponse{Id = Guid.NewGuid(), NumberOfQuestions = 2, Title = "Title_2", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsFavorite = true},
            new QuizResponse{Id = Guid.NewGuid(), NumberOfQuestions = 2, Title = "Title_3", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsFavorite = true},
            new QuizResponse{Id = Guid.NewGuid(), NumberOfQuestions = 2, Title = "Title_4", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsFavorite = true},
        };

        protected override async Task OnInitializedAsync()
        {
            var customAuthStateProvider = (CustomAuthenticationStateProvider)_authStateProvider;
            user = await customAuthStateProvider.GetUserAsync();
        }
    }
}
