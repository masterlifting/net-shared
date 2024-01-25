using System;

namespace Net.Shared.Abstractions.Models.Settings;

public sealed record CorrelationSettings
{
    public const string SectionName = "Correlation";
    public Guid Id { get; init; }
}
