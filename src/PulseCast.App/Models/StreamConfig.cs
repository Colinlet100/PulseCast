namespace PulseCast.App.Models;

public sealed class StreamConfig
{
    public string ServerUrl { get; set; } = "rtmp://localhost/live";
    public string StreamKey { get; set; } = string.Empty;
    public string Encoder { get; set; } = "x264";
    public int BitrateKbps { get; set; } = 6000;
}
