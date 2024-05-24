namespace BloodBank.Core.Results.Errors;

public sealed record Error(string Code, string Message) : IError
{
    public static readonly Error None = new(string.Empty, string.Empty);
}