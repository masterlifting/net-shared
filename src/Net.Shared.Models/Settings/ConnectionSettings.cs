namespace Net.Shared.Models.Settings;

public abstract record ConnectionSettings
{
    public string Host { get; init; } = null!;
    public int Port { get; init; }
    public string User { get; init; } = null!;
    public string Password { get; init; } = null!;
}
