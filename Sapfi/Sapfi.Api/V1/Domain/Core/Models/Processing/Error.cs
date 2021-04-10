namespace Sapfi.Api.V1.Domain.Core.Models.Processing
{
    public class Error
    {
        public string Title { get; private set; }
        public string Message { get; private set; }

        public Error(string title, string message)
        {
            Title = title;
            Message = message;
        }
    }
}
