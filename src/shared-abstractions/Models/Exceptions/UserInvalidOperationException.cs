using System;

namespace Net.Shared.Abstractions.Models.Exceptions;

public class UserInvalidOperationException(string error) : InvalidOperationException(error)
{
}
