using System.Text.Json.Serialization;

namespace Shared
{
    public class Response<T>
    {

        public T Data { get; set; }
        public bool IsSuccessful { get; set; }
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }


        public Response()
        {
            Errors = new List<string>();
        }

        public static Response<T> Success(T Data, int StatusCode)
        {
            return new Response<T>()
            {
                Data = Data,
                StatusCode = StatusCode,
                IsSuccessful = true
            };
        }

        public static Response<T> Success(int StatusCode)
        {
            return new Response<T>()
            {
                Data = default(T),
                StatusCode = StatusCode,
                IsSuccessful = true
            };
        }

        public static Response<T> Error(List<string> errors, int statusCode)
        {
            return new Response<T>()
            {
                IsSuccessful = false,
                StatusCode = statusCode,
                Errors = errors
            };
        }

        public static Response<T> Error(string errorMessage, int statusCode)
        {
            return new Response<T>
            {
                IsSuccessful = false,
                StatusCode = statusCode,
                Errors = new List<string>() { errorMessage }
            };
        }
    }

}
