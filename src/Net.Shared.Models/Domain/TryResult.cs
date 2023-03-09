using System;

namespace Net.Shared.Models.Domain;

public sealed record TryResult<T>
{
    public T? Result { get; }
    public bool IsSuccess { get; }
    public string[] Errors { get; }

    public TryResult(T data)
    {
        Result = data;
        IsSuccess = true;
        Errors = Array.Empty<string>();
    }
    public TryResult(string[] errors)
    {
        IsSuccess = false;
        Errors = errors;
    }
    public TryResult(string error)
    {
        IsSuccess = false;
        Errors = new[] { error };
    }
    public TryResult(Exception exception)
    {
        IsSuccess = false;
        Errors = exception.InnerException is null
            ? new string[] { exception.Message }
            : new string[] { exception.Message, exception.InnerException.Message };
    }
}