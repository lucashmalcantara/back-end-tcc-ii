namespace Sapfi.Api.V1.Domain.Core.Models
{
    public sealed class SimpleResult
    {
        public Error Error { get; private set; }
        public bool HasError => Error != null;

        private SimpleResult(Error error) =>
            Error = error;

        private SimpleResult() { }

        public static SimpleResult Success() =>
            new SimpleResult(null);

        public static SimpleResult Fail(Error error) =>
            new SimpleResult(error);
    }
}
