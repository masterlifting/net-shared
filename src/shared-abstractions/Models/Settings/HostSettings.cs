using System;

namespace Net.Shared.Abstractions.Models.Settings
{
    public sealed record HostSettings
    {
        public const string SectionName = "Host";
        public Guid Id { get; init; }
    }
}
