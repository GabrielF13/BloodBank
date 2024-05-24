namespace BloodBank.Core.Results.Errors
{
    public interface IError
    {
        string Code { get; init; }
        string Message { get; init; }
    }
}