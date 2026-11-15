using PulseCast.App.Models;
namespace PulseCast.App.Services;
public static class FfmpegCommandBuilder
{
    public static string Build(StreamConfig config)
    {
        var encoder = config.Encoder.ToLower() switch
        {
            "nvenc" => "h264_nvenc",
            "qsv" => "h264_qsv",
            "amf" => "h264_amf",
            _ => "libx264"
        };
        return $"-c:v {encoder} -b:v {config.BitrateKbps}k -f flv {config.ServerUrl}/{config.StreamKey}";
    }
}