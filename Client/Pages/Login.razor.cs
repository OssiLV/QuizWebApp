namespace QuizWebApp.Client.Pages
{
    public partial class Login
    {
        private bool isRegisterPage = true;

        public void ChangeLoginAndRegisterPage()
        {
            isRegisterPage = !isRegisterPage;
        }


    }
}
