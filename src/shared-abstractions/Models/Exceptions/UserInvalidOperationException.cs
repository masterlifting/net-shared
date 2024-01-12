using System;

namespace Net.Shared.Abstractions.Models.Exceptions;

public sealed class UserInvalidOperationException(string error) : InvalidOperationException(error)
{
}
