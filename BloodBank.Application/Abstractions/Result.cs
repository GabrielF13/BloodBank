namespace BloodBank.Application.Abstractions
{
    public class Result<T>
    {
        public Result(bool isSuccess, string message, bool isFound = true, T data = default)
        {
            IsSuccess = isSuccess;
            IsFound = isFound;
            Message = message;
            Data = data;
        }

        public bool IsSuccess { get; set; }
        public bool IsFound { get; set; }
        public string Message { get; set; }
        public T Data { get; }

        public static Result<T> Success(T data, string message = "Operação bem-sucedida.")
        {
            return new Result<T>(true, message, data: data);
        }

        public static Result<T> Failure(string message = "Operação falhou.")
        {
            return new Result<T>(false, message);
        }

        public static Result<T> NotFound(string message = "Não encontrado.")
        {
            return new Result<T>(false, message, false);
        }
    }
}