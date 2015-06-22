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
using System.Data;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Threading;
using System.ServiceProcess;
using SimpleCove.Library;
using SimpleCove.Service;
using SimpleCove.Controls;
using System.Drawing;
using SettingsViewModel;


namespace SimpleCove
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceController windowsService = new ServiceController();
        AppSettingsViewModel settings = new AppSettingsViewModel();
        

        private NotifyIcon MyNotifyIcon;

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                MyNotifyIcon = new NotifyIcon();
#if DEBUG
                lblDebug.Visibility = Visibility.Visible;
                MyNotifyIcon.Icon = new System.Drawing.Icon(@"C:\Projects\SimpleCove\SimpleCove\Icons\NetDrives.ico");
#else
                MyNotifyIcon.Icon = new System.Drawing.Icon(Directory.GetCurrentDirectory() + @"\Icons\NetDrives.ico");
#endif
                MyNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(MyNotifyIcon_MouseClick);

                if (Convert.ToBoolean(rbDestType1.IsChecked))
                    btnFTPSettings.Visibility = Visibility.Visible;
                else if (Convert.ToBoolean(rbDestType2.IsChecked))
                    btnFTPSettings.Visibility = Visibility.Hidden;

                ddInterval.SelectedIndex = Convert.ToInt32(Properties.Settings.Default["Interval"]);
                ServiceController[] allServices = ServiceController.GetServices();

                foreach (ServiceController service in allServices)
                {
                    if (service.DisplayName == "SimpleCoveService")
                        windowsService = service;
                }

                if (windowsService.ServiceName.Length > 0 && windowsService.Status == ServiceControllerStatus.Stopped)
                    btnStop.IsEnabled = false;
                else
                    btnStart.IsEnabled = false;



                dtpStartTime.Text = DateTimeConvertor(Convert.ToDateTime(Properties.Settings.Default["StartTime"]));
               

                txtFilePath.Text = Properties.Settings.Default["FilePath"].ToString();
                txtDestinationPath.Text = Properties.Settings.Default["DestinationPath"].ToString();
            }
            catch (Exception ex)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message);
            }
        }

        private string DateTimeConvertor(DateTime dt)
        {
            string customDateTime = dt.ToShortTimeString() + " " + dt.ToShortDateString();


            return customDateTime;
        }

        private void Save()
        {
            Properties.Settings.Default.FilePath = txtFilePath.Text;
            Properties.Settings.Default.DestinationPath = txtDestinationPath.Text;
            Properties.Settings.Default.Interval = ddInterval.SelectedIndex;
            //Properties.Settings.Default.StartTime = Convert.ToDateTime(dtpStartTime.Text);

            Properties.Settings.Default.Save();
        }

        public static void StartService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch (Exception ex)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message);
            }
        }

        public static void StopService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
            }
            catch (Exception ex)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(ex.Message);
            }
        }

        // Button Functions

        private void btnFTPSettings_Click(object sender, RoutedEventArgs e)
        {
            FtpSettings ftpSettings = new FtpSettings();
            ftpSettings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ftpSettings.Show();
        }

        private void btnBrowseDest_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToBoolean(rbDestType1.IsChecked))
            {
                FtpBrowser ftpBrowser = new FtpBrowser();
                ftpBrowser.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                ftpBrowser.Show();
            }
            else
            {

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowNewFolderButton = true;

                if (txtFilePath.Text.Length > 0)
                    fbd.SelectedPath = @txtDestinationPath.Text;
                else
                    fbd.RootFolder = Environment.SpecialFolder.MyComputer;

                DialogResult result = fbd.ShowDialog();

                if (fbd.SelectedPath.Length > 0)
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    txtDestinationPath.Text = fbd.SelectedPath;
                }

            }
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;

            if (txtFilePath.Text.Length > 0)
                fbd.SelectedPath = @txtFilePath.Text;
            else
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;

            DialogResult result = fbd.ShowDialog();

            if (fbd.SelectedPath.Length > 0)
            {
                string[] files = Directory.GetFiles(fbd.SelectedPath);
                txtFilePath.Text = fbd.SelectedPath;
            }

        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            // NOTE: 
            // if you are having trouble starting try adding <requestedExecutionLevel level="requireAdministrator" uiAccess="false" /> 
            // to the .Manifest file in in the output folder
            // Find a way to send profile settings to app


#if DEBUG

            //Thread thread = Thread.CurrentThread;
            //this.DataContext = new
            //{
            //    ThreadId = thread.ManagedThreadId
            //};

            Properties.Settings.Default["Run"] = true;
            Properties.Settings.Default.Save();
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
            lblStatus.Visibility = Visibility.Visible;
            lblStatus.Content = "RUNNING";

            string[] args = { "true", "test" };

            settings.StartTime = Convert.ToDateTime(Properties.Settings.Default["StartTime"]);
            settings.DestType1 = Convert.ToBoolean(Properties.Settings.Default["DestType1"]);
            settings.DestType2 = Convert.ToBoolean(Properties.Settings.Default["DestType2"]);
            settings.Host = Properties.Settings.Default["Username"].ToString();
            settings.User = Properties.Settings.Default["Host"].ToString();
            settings.Pass = Properties.Settings.Default["Password"].ToString();
            settings.Run = true;
            settings.DestinationPath = txtDestinationPath.Text;
            settings.FilePath = txtFilePath.Text;

            Service.WindowsService.s = settings;
            Service.WindowsService myScheduler = new Service.WindowsService();
            Thread thread = new Thread(() =>
            {
                //Window1 w = new Window1();
                //w.Show();

                //w.Closed += (sender2, e2) =>
                // w.Dispatcher.InvokeShutdown();

                myScheduler.onDebug(args);
                System.Windows.Threading.Dispatcher.Run();
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();


#else

            Properties.Settings.Default["Run"] = true;
            Properties.Settings.Default.Save();
            btnStart.IsEnabled = false;
            btnStop.IsEnabled = true;
            StartService(windowsService.ServiceName, 120000);

#endif

        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {

#if DEBUG

            Properties.Settings.Default["Run"] = true;
            Properties.Settings.Default.Save();
#else
            lblStatus.Visibility = Visibility.Hidden;
            Properties.Settings.Default["Run"] = false;
            Properties.Settings.Default.Save();
            btnStop.IsEnabled = false;
            btnStart.IsEnabled = true;
            StopService(windowsService.ServiceName, 120000);
#endif
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Save();
            WindowState = WindowState.Minimized;
        }

        // Event Functions

        void MyNotifyIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            this.WindowState = WindowState.Normal;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                MyNotifyIcon.BalloonTipTitle = "Heads up!";
                MyNotifyIcon.BalloonTipText = "I'll be right here if you need me :)";
                MyNotifyIcon.ShowBalloonTip(400);
                MyNotifyIcon.Visible = true;


                // new InlineContextMenuWindow();
            }
            else if (this.WindowState == WindowState.Normal)
            {
                MyNotifyIcon.Visible = false;
                this.ShowInTaskbar = true;
            }
        }

        private void rbDestType1_Checked(object sender, RoutedEventArgs e)
        {
            if (btnFTPSettings != null)
                btnFTPSettings.Visibility = Visibility.Visible;
        }

        private void rbDestType2_Checked(object sender, RoutedEventArgs e)
        {
            if (btnFTPSettings != null)
                btnFTPSettings.Visibility = Visibility.Hidden;
        }

    }
}
