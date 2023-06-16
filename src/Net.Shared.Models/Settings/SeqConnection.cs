namespace Net.Shared.Models.Settings;

public sealed record SeqConnection : Connection
{
    public const string Name = "SeqConnection";
    public string ConnectionString => $"http://{Host}:{Port}";
}