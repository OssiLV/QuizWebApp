namespace QuizWebApp.Shared.ResponseDtos
{
    public class ResponseObjectDto<T>
    {
        public int status { get; set; }
        public string message { get; set; }
        public T result { get; set; }

        public ResponseObjectDto( int status, string message, T? result )
        {
            this.status = status;
            this.message = message;
            this.result = result;
        }
    }
}
