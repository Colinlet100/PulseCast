using System.Windows.Forms;

namespace PulseCast.App;

public class MainForm : Form
{
    public MainForm()
    {
        Text = "PulseCast MVP";
        Width = 900;
        Height = 600;

        var hostLabel = new Label { Text = "RTMP / RTMPS URL", Left = 20, Top = 20, Width = 200 };
        var hostBox = new TextBox { Left = 20, Top = 45, Width = 600, Text = "rtmp://localhost/live" };

        var streamKeyLabel = new Label { Text = "Stream Key", Left = 20, Top = 90, Width = 200 };
        var streamKeyBox = new TextBox { Left = 20, Top = 115, Width = 600, UseSystemPasswordChar = true };

        var encoderLabel = new Label { Text = "Encoder", Left = 20, Top = 160, Width = 100 };
        var encoderBox = new ComboBox { Left = 20, Top = 185, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
        encoderBox.Items.AddRange(new object[] { "NVENC", "QSV", "AMF", "x264" });
        encoderBox.SelectedIndex = 3;

        var bitrateLabel = new Label { Text = "Bitrate (kbps)", Left = 250, Top = 160, Width = 120 };
        var bitrateBox = new NumericUpDown { Left = 250, Top = 185, Width = 120, Minimum = 500, Maximum = 50000, Value = 6000 };

        var startButton = new Button { Text = "Start Stream", Left = 20, Top = 250, Width = 150 };
        var stopButton = new Button { Text = "Stop", Left = 180, Top = 250, Width = 150, Enabled = false };

        var status = new Label { Text = "Ready", Left = 20, Top = 310, Width = 500, Height = 30 };

        startButton.Click += (_, _) =>
        {
            status.Text = $"Configured: {hostBox.Text} ({encoderBox.Text}, {bitrateBox.Value} kbps)";
            startButton.Enabled = false;
            stopButton.Enabled = true;
        };

        stopButton.Click += (_, _) =>
        {
            status.Text = "Stopped";
            startButton.Enabled = true;
            stopButton.Enabled = false;
        };

        Controls.AddRange(new Control[] { hostLabel, hostBox, streamKeyLabel, streamKeyBox, encoderLabel, encoderBox, bitrateLabel, bitrateBox, startButton, stopButton, status });
    }
}
