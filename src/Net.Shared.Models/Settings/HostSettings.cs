using System;

namespace Net.Shared.Models.Settings;

public sealed record HostSettings
{
    public const string Name = "Host";
    public Guid Id { get; init; }
}