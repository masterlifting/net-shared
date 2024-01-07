using Microsoft.Extensions.Logging;

namespace Net.Shared.Extensions.Logging;

internal static class LogEvents
{
    internal static readonly EventId Error = new(1000, "error native log");
    internal static readonly EventId Warning = new(1001, "warning native log");
    internal static readonly EventId Information = new(1002, "information native log");
    internal static readonly EventId Debug = new(1003, "debug native log");
    internal static readonly EventId Trace = new(1004, "trace native log");
}
