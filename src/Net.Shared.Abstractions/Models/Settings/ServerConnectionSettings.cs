using System.ComponentModel.DataAnnotations;

namespace Net.Shared.Abstractions.Models.Settings;

public abstract record ServerConnectionSettings : CredentialConnectionSettings
{
    [Required] public string Host { get; init; } = null!;
    [Range(1, 65535)] public int Port { get; init; }
}
