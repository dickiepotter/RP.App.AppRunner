using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RP.App.AppRunner
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Timers;

    using RP.Util.Icon;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Timer pollTimer;
        private Process process;

        public MainWindow()
        {
            InitializeComponent();

            pollTimer = new Timer(100);
            pollTimer.Elapsed += UpdateTick;
        }

        private void UpdateTick(object sender, ElapsedEventArgs e)
        {
            pollTimer.Stop();
            Dispatcher.Invoke(new Action(Update));
            pollTimer.Start();
        }

        private void HandleRun(object sender, RoutedEventArgs e)
        {
            Clear();
            Stop();

            try
            {
                ProcessStartInfo info = new ProcessStartInfo(path.Text, args.Text);
                info.RedirectStandardError = true;
                info.RedirectStandardOutput = true;
                info.UseShellExecute = false;
                info.ErrorDialog = false;

                process = new Process();
                process.StartInfo = info;
                process.OutputDataReceived += process_OutputDataReceived;
                process.ErrorDataReceived += process_ErrorDataReceived;
                process.Exited += process_Exited;

                process.Start();

                Update();

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                detailsExpander.IsEnabled = true;
                outputExpander.IsEnabled = true;

                detailsExpander.IsExpanded = true;
                outputExpander.IsExpanded = true;

                pollTimer.Start();

                try
                {
                    shellIcon.Source = IconExtractor.GetAssociatedIconLarge(path.Text).ToImageSource();
                }
                catch
                {
                    shellIcon.Source = null;
                }
            }
            catch
            {
                process = null;
                Clear();
            }
        }

        private void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Dispatcher.Invoke
              (
                new Action
                  (
                  delegate { stdError.AppendText(e.Data + "\n"); }
                  )
              );
        }

        private void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Dispatcher.Invoke
              (
                new Action
                  (
                  delegate { stdOutput.AppendText(e.Data + "\n"); }
                  )
              );
        }

        private void process_Exited(object sender, EventArgs e)
        {
            pollTimer.Stop();
            Update();
        }

        private void HandleStop(object sender, RoutedEventArgs e)
        {
            Stop();
        }

        private void Stop()
        {
            if (process != null && !process.HasExited)
            {
                if (process.MainWindowHandle != IntPtr.Zero)
                    process.CloseMainWindow();
                else
                    process.Kill();
            }
        }

        private void Update()
        {
            try
            {
                id.Text = process.Id.ToString();
            }
            catch
            {
            }
            try
            {
                priority.Text = process.BasePriority.ToString();
            }
            catch
            {
            }
            try
            {
                exitCode.Text = process.ExitCode.ToString();
            }
            catch
            {
            }
            try
            {
                workingSet.Text = process.WorkingSet64.ToString();
            }
            catch
            {
            }
            try
            {
                totalProcessor.Text = process.TotalProcessorTime.ToString();
            }
            catch
            {
            }
        }

        private void Clear()
        {
            id.Text = string.Empty;
            priority.Text = string.Empty;
            exitCode.Text = string.Empty;
            workingSet.Text = string.Empty;

            stdOutput.Clear();
            stdError.Clear();
        }

        private void path_Drop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0) path.Text = files[0];
        }

        private void path_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.All;
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Stop();
        }
    }
}
