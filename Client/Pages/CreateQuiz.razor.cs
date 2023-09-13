using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using QuizWebApp.Client.Authentication;
using QuizWebApp.Shared.RequestDtos;
using QuizWebApp.Shared.ResponseDtos;
using System.Net.Http.Json;

namespace QuizWebApp.Client.Pages
{
    public partial class CreateQuiz
    {
        [Inject]
        AuthenticationStateProvider _authStateProvider { get; set; }
        [Inject]
        HttpClient _http { get; set; }
        [Inject]
        NavigationManager _navigationManager { get; set; }

        public string title { get; set; }
        public string description { get; set; } = string.Empty;
        public bool isFavorite { get; set; } = false;
        public bool isTwoQuestion { get; set; } = true;

        // Validate Title
        public bool isTitleError { get; set; }
        public string errorTitleMessage { get; set; }

        // Validate Questions
        public bool isQuestionError { get; set; }
        public string errorQuestionMessage { get; set; }
        private UserResponse user { set; get; }


        protected override async Task OnInitializedAsync()
        {
            var customAuthStateProvider = (CustomAuthenticationStateProvider)_authStateProvider;
            user = await customAuthStateProvider.GetUserAsync();
        }
        List<QuestionCreateRequest> questionsRequest = new List<QuestionCreateRequest>();

        List<FrameQuestion> frameQuestions = new List<FrameQuestion>
        {
            new FrameQuestion(){Id = 1, QuestionCreateRequest = new QuestionCreateRequest() { Id = Guid.NewGuid(), Content = "", Answer = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, QuizId = Guid.Empty} },
            new FrameQuestion(){Id = 2, QuestionCreateRequest = new QuestionCreateRequest() { Id = Guid.NewGuid(), Content = "", Answer = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, QuizId = Guid.Empty} },
        };

        private class FrameQuestion
        {
            public int Id { get; set; }
            public QuestionCreateRequest QuestionCreateRequest;
        }


        public void AddNewQuestion()
        {
            int currentMaxId = frameQuestions.Max(x => x.Id);
            frameQuestions.Add(new FrameQuestion() { Id = currentMaxId + 1, QuestionCreateRequest = new QuestionCreateRequest() { Id = Guid.NewGuid(), Content = "", Answer = "", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, QuizId = Guid.Empty } });
            isTwoQuestion = false;
        }

        public void DeleteQuestion( int id )
        {
            var currentQuestion = frameQuestions.Find(x => x.Id == id);
            /*  var index = questions.IndexOf(currentQuestion);*/
            if(frameQuestions.Count > 2)
            {
                frameQuestions.Remove(currentQuestion);
                for(int i = 0; i < frameQuestions.Count; i++)
                {
                    if(frameQuestions[i].Id > id)
                    {
                        frameQuestions[i].Id--;
                    }
                }
                isTwoQuestion = false;
            }
            if(frameQuestions.Count == 2)
            {
                isTwoQuestion = true;
            }
        }

        public async Task HandleAddNewQuizAsync()
        {
            if(string.IsNullOrWhiteSpace(title) && string.IsNullOrWhiteSpace(title))
            {
                isTitleError = true;
                errorTitleMessage = "Your title must not empty!";
                return;
            }

            isTitleError = false;


            // Validate Question
            int count = 0;

            for(int i = 0; i < frameQuestions.Count; i++)
            {
                if(!string.IsNullOrEmpty(frameQuestions[i].QuestionCreateRequest.Content) && !string.IsNullOrEmpty(frameQuestions[i].QuestionCreateRequest.Answer))
                {
                    count++;
                }
            }

            if(count > 0)
            {
                isQuestionError = false;

            }
            else if(count == 0)
            {
                isQuestionError = true;
                errorQuestionMessage = "Cannot empty!";
                return;
            }

            Guid guidId = Guid.NewGuid();

            QuizCreateRequest QuizCreateRequest = new QuizCreateRequest();
            QuizCreateRequest.Id = guidId;
            QuizCreateRequest.Title = title;
            QuizCreateRequest.Description = description;
            QuizCreateRequest.IsFavorite = isFavorite;
            QuizCreateRequest.CreatedAt = DateTime.Now;
            QuizCreateRequest.UpdatedAt = DateTime.Now;
            QuizCreateRequest.UserId = user.Id;

            foreach(var question in frameQuestions)
            {
                question.QuestionCreateRequest.QuizId = QuizCreateRequest.Id;
                if(!questionsRequest.Contains(question.QuestionCreateRequest))
                {
                    questionsRequest.Add(question.QuestionCreateRequest);

                }
            }

            questionsRequest.RemoveAll(x => string.IsNullOrEmpty(x.Content) || string.IsNullOrEmpty(x.Answer));
            questionsRequest.Distinct();

            QuizCreateRequest.questionCreateRequests = questionsRequest;

            var customAuthStateProvider = (CustomAuthenticationStateProvider)_authStateProvider;
            var token = await customAuthStateProvider.GetToken();
            if(!string.IsNullOrEmpty(token))
            {

                _http.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token);
                await _http.PostAsJsonAsync("/api/Quiz", QuizCreateRequest);
                _navigationManager.NavigateTo($"/quiz/{QuizCreateRequest.Id}");

            }
            else
            {
                _navigationManager.NavigateTo("/login");
            }

            return;
        }



    }
}
