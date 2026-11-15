using System.Diagnostics;
using PulseCast.App.Models;
namespace PulseCast.App.Services;
public sealed class StreamService
{
    private Process? process;
    public StreamStatus Status { get; private set; } = StreamStatus.Stopped;
    public event Action<StreamStatus>? StatusChanged;
    public void Start(StreamConfig config)
    {
        if (Status != StreamStatus.Stopped) return;
        Status = StreamStatus.Starting; StatusChanged?.Invoke(Status);
        process = new Process();
        process.StartInfo = new ProcessStartInfo{
            FileName="cmd.exe",
            Arguments="/c echo PulseCast streaming engine initialized && timeout /t 9999 > nul",
            UseShellExecute=false,CreateNoWindow=true};
        process.EnableRaisingEvents=true;
        process.Exited += (_,_)=> { Status = StreamStatus.Stopped; StatusChanged?.Invoke(Status); };
        process.Start();
        Status = StreamStatus.Running; StatusChanged?.Invoke(Status);
    }
    public void Stop(){ try{ if(process is {HasExited:false}) process.Kill(true);}catch{} Status=StreamStatus.Stopped; StatusChanged?.Invoke(Status);} 
}