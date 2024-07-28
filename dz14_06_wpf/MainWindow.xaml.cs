using System.Diagnostics;
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

        public void SetCurrentProcess(Process process)
        {
            currentProcess = process;
        }

        private async void CalcButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "calc.exe";
            process.Start();

            SetCurrentProcess(process);

            await Task.Run(() => process.WaitForExit());

            int exitCode = process.ExitCode;

            ResultTextBlock.Text = $"Process exited with code: {exitCode}";
        }

        private async void NotepadButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "notepad.exe";
            process.Start();

            SetCurrentProcess(process);

            await Task.Run(() => process.WaitForExit());

            int exitCode = process.ExitCode;

            ResultTextBlock.Text = $"Process exited with code: {exitCode}";
        }

        private async void CalendarButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "calendar.exe"; // Замініть "calendar.exe" на правильну назву
            process.Start();

            SetCurrentProcess(process);

            await Task.Run(() => process.WaitForExit());

            int exitCode = process.ExitCode;

            ResultTextBlock.Text = $"Process exited with code: {exitCode}";
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentProcess != null && !currentProcess.HasExited)
            {
                currentProcess.Kill();
                ResultTextBlock.Text = "Process has been terminated.";
            }
        }
    }
}
