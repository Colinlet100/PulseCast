using System.Diagnostics;
using PulseCast.App.Models;

namespace PulseCast.App.Services;

public sealed class StreamService
{
    private Process? _process;
    public bool IsStreaming => _process is { HasExited: false };

    public void Start(StreamConfig config)
    {
        if (IsStreaming) return;

        var sanitizedTarget = $"{config.ServerUrl}/[REDACTED]";
        var args = $"Streaming target: {sanitizedTarget}";

        _process = new Process();
        _process.StartInfo = new ProcessStartInfo
        {
            FileName = "cmd.exe",
            Arguments = $"/c echo {args} && timeout /t 9999 > nul",
            CreateNoWindow = true,
            UseShellExecute = false
        };

        _process.Start();
    }

    public void Stop()
    {
        try
        {
            if (_process is { HasExited: false })
                _process.Kill(true);
        }
        catch { }
    }
}
