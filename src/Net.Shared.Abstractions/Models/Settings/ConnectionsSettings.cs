namespace Net.Shared.Abstractions.Models.Settings;

public abstract record ConnectionsSettings
{
    public abstract string ConnectionString { get; }
}
