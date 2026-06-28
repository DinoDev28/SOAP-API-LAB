using System.Diagnostics;
namespace MiniPaymentGatewayServer.Services
{
    public enum NgrokMode
    {
        Hidden,
        Visible
    }
    public class PortForwarder
    {
        public Process NgrokForward(int port, NgrokMode mode)
        {
            ProcessStartInfo startInfo;

            switch (mode)
            {
                // Background mode (no window)
                case NgrokMode.Hidden:
                    startInfo = new ProcessStartInfo
                    {
                        FileName = "ngrok.exe",
                        Arguments = $"http {port}",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };
                    break;

                // Visible CMD window
                case NgrokMode.Visible:
                    startInfo = new ProcessStartInfo
                    {
                        FileName = "ngrok.exe",
                        Arguments = $"http {port}",
                        UseShellExecute = true,
                        CreateNoWindow = false
                    };
                    break;

                default:
                    throw new ArgumentException("Invalid execution option.");
            }

            Process process = new Process();
            process.StartInfo = startInfo;

            process.Start();

            // Only possible when UseShellExecute = false
            if (!startInfo.UseShellExecute)
            {
                process.OutputDataReceived += (sender, e) =>
                {
                    if (!string.IsNullOrEmpty(e.Data))
                        Console.WriteLine(e.Data);
                };

                process.BeginOutputReadLine();
            }
            return process;
        }
    }
}
