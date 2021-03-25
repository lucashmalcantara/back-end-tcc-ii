using System.Net;

namespace Sapfi.Api.V1.Domain.Core.Models
{
    public class ErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Title { get; private set; }
        public string Message { get; private set; }

        public ErrorResponse(HttpStatusCode statusCode, string title, string message)
        {
            StatusCode = statusCode;
            Title = title;
            Message = message;
        }
    }
}
