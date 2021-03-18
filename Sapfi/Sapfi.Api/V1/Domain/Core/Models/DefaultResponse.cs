using System.Collections.Generic;

namespace Sapfi.Api.V1.Domain.Core.Models
{
    public sealed class DefaultResponse<T>
    {
        public T Data { get; private set; }
        public bool Error { get; private set; }
        public IEnumerable<string> Messasges { get; private set; }

        private DefaultResponse(T data, bool error, IEnumerable<string> messasges)
        {
            Data = data;
            Error = error;
            Messasges = messasges;
        }

        public static DefaultResponse<T> Success(T data)
        {
            return new DefaultResponse<T>(data, false, new List<string>());
        }

        public static DefaultResponse<T> Fail(T data, List<string> messages)
        {
            return new DefaultResponse<T>(data, true, messages);
        }

        public static DefaultResponse<T> Fail(T data, string message)
        {
            return new DefaultResponse<T>(data, true, new List<string> { message });
        }
    }
}
