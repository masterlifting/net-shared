using System.ComponentModel.DataAnnotations;

namespace Net.Shared.Abstractions.Models.Settings;

public abstract record SecretConnectionSettings : ConnectionsSettings
{
    [Required] public string SecretKey { get; init; } = null!;
}
