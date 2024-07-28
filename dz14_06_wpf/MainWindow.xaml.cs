using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace dz14_06_wpf
{
    public partial class MainWindow : Window
    {
        private Process currentProcess;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void NotepadButtonStart_Click(object sender, RoutedEventArgs e)
        {
            int number1 = 5;
            int number2 = 10;
            string filePath = "D:\\exe\\Davinci Resolve\\Resolve.exe";

            string tempFilePath = Path.GetTempFileName();
            File.WriteAllText(tempFilePath, $"{number1}\n{number2}\n{filePath}");

            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "notepad.exe",
                    Arguments = tempFilePath
                }
            };

            process.Start();
            await Task.Run(() => process.WaitForExit());

            int exitCode = process.ExitCode;

            ResultTextBlock.Text = $"Process exited with code: {exitCode}";
        }
    }
}
