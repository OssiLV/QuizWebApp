using MudBlazor;
using QuizWebApp.Shared.ResponseDtos;

namespace QuizWebApp.Client.Pages
{
    public partial class CreateQuiz
    {
        private string title { get; set; }
        private string description { get; set; }

        private MudDropContainer<QuestionResponse> _dropContainer;
        List<QuestionResponse> listQuestion = new()
        {
            new QuestionResponse() {Id= Guid.NewGuid(), Content="Content_1", Answer="Anser_1", CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now},
            new QuestionResponse() {Id= Guid.NewGuid(), Content="Content_2", Answer="Anser_2", CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now},
            new QuestionResponse() {Id= Guid.NewGuid(), Content="", Answer="", CreatedAt=DateTime.Now, UpdatedAt = DateTime.Now},
        };

        private void AddNewQuestion()
        {
            var test = listQuestion.Where(x => !string.IsNullOrEmpty(x.Content) || !string.IsNullOrEmpty(x.Answer));
            Console.WriteLine(test.Count());
            /*listQuestion.Add(new QuestionResponse() { Id=Guid.NewGuid(), Content = "" })*/
        }

        private void QuestionUpdated( MudItemDropInfo<QuestionResponse> info )
        {
            info.Item.Answer = info.DropzoneIdentifier;
        }

















        List<QuizResponse> listQuiz = new List<QuizResponse>
        {
            new QuizResponse{Id = Guid.NewGuid(), NumberOfQuestions = 2, Title = "Title_1", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsFavorite = true},
            new QuizResponse{Id = Guid.NewGuid(), NumberOfQuestions = 2, Title = "Title_2", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsFavorite = true},
            new QuizResponse{Id = Guid.NewGuid(), NumberOfQuestions = 2, Title = "Title_3", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsFavorite = true},
            new QuizResponse{Id = Guid.NewGuid(), NumberOfQuestions = 2, Title = "Title_4", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, IsFavorite = true},
        };
    }
}
