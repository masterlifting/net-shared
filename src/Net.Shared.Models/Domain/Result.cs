using System;
using System.Collections.Generic;
using System.Linq;

namespace Net.Shared.Models.Domain;

public sealed record Result<T>
{
    public T[] Data { get; }
    public bool IsSuccess { get; }
    public string[] Errors { get; }

    public Result(bool isSuccess)
    {
        IsSuccess = isSuccess;
        Data = Array.Empty<T>();
        Errors = isSuccess
            ? Array.Empty<string>()
            : new[] { "Result unknown error" };
    }

    public Result(T data)
    {
        IsSuccess = true;
        Data = new[] { data };
        Errors = Array.Empty<string>();
    }

    public Result(IEnumerable<T> data)
    {
        IsSuccess = true;
        Data = data.ToArray();
        Errors = Array.Empty<string>();
    }

    public Result(string[] errors)
    {
        IsSuccess = false;
        Data = Array.Empty<T>();
        Errors = errors;
    }

    public Result(string error)
    {
        IsSuccess = false;
        Data = Array.Empty<T>();
        Errors = new[] { error };
    }

    public Result(Exception exception)
    {
        IsSuccess = false;
        Data = Array.Empty<T>();
        Errors = exception.InnerException is null
            ? new string[] { exception.Message }
            : new string[] { exception.Message, exception.InnerException.Message };
    }

    public string GetError() => string.Join(", ", Errors);
}