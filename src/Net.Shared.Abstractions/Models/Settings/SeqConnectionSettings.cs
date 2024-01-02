namespace Net.Shared.Abstractions.Models.Settings
{
    public sealed record SeqConnection : ServerConnectionSettings
    {
        public const string SectionName = "SeqConnection";
        public override string ConnectionString => $"http://{Host}:{Port}";
    }
}
