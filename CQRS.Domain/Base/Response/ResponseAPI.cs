namespace CQRS.Domain.Base
{
    public abstract class BaseResponseAPI
    {
        public BaseResponseAPI(bool success, string? message)
        {
            Success = success;
            Message = message ?? "Operação realizada com sucesso!";
        }

        public bool Success { get; set; }
        public string Message { get; set; } = "Operation realizes successfuly!";
    }

    public class ResponseAPI<T> : BaseResponseAPI
    {
        public ResponseAPI(bool success, string? message, T? data) : base(success, message)
        {
            Data = data;
        }

        public T? Data { get; set; }
    }

    public class ResponseAPI : BaseResponseAPI
    {
        public ResponseAPI(bool success, string? message, object? data) : base(success, message)
        {
            Data = data;
        }
        public object? Data { get; set; }
    }

    public class ResponseErrorAPI : BaseResponseAPI
    {
        public ResponseErrorAPI(bool success, string? message, List<string> errors) : base(success, message)
        {
            Errors = errors;
        }
        public List<string>? Errors { get; set; }
    }
}
