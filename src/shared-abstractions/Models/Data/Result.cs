using System;
using System.Collections.Generic;
using System.Linq;

namespace Net.Shared.Abstractions.Models.Data;

public sealed record Result<T>
{
    public T[] Data { get; }
    public string[] Errors { get; }

    public Result(T data)
    {
        Data = [data];
        Errors = [];
    }

    public Result(IEnumerable<T> data)
    {
        Data = data.ToArray();
        Errors = [];
    }

    public Result(Exception exception)
    {
        Data = [];
        Errors = exception.InnerException is null
            ? [exception.Message]
            : [exception.Message, exception.InnerException.Message];
    }

    public Result(string error)
    {
        Data = [];
        Errors = [error];
    }

    public Result(IEnumerable<string> errors)
    {
        Data = [];
        Errors = errors.ToArray();
    }

    public Result(IEnumerable<T> data, IEnumerable<string> errors)
    {
        Data = data.ToArray();
        Errors = errors.ToArray();
    }

    public string GetError() => string.Join(", ", Errors);
}
