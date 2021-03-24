namespace Sapfi.Api.V1.Domain.Core.Models
{
    public sealed class DefaultResponse<T>
    {
        public T Data { get; private set; }
        public bool HasError { get; private set; }
        public ErrorResponse ErrorResponse { get; private set; }

        private DefaultResponse(T data, bool hasError, ErrorResponse errorResponse)
        {
            Data = data;
            HasError = hasError;
            ErrorResponse = errorResponse;
        }

        public static DefaultResponse<T> Success(T data)
        {
            return new DefaultResponse<T>(data, false, null);
        }

        public static DefaultResponse<T> Fail(ErrorResponse errorResponse)
        {
            return new DefaultResponse<T>(default, true, errorResponse);
        }
    }
}
