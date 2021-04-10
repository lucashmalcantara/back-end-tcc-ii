namespace Sapfi.Api.V1.Domain.Core.Models
{
    public sealed class Result<T>
    {
        public T Data { get; private set; }
        public Error Error { get; private set; }
        public bool HasError => Error != null;

        private Result(T data, Error error)
        {
            Data = data;
            Error = error;
        }

        private Result() { }

        public static Result<T> Success(T data) =>
            new Result<T>(data, null);

        public static Result<T> Fail(Error error) =>
            new Result<T>(default, error);
    }
}
