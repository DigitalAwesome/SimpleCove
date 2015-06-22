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
using System.Windows.Shapes;
using SimpleCove.Library;

namespace SimpleCove
{
    /// <summary>
    /// Interaction logic for FtpBrowser.xaml
    /// </summary>
    public partial class FtpBrowser : Window
    {
        public FTPclient ftp = new FTPclient();

        public FtpBrowser()
        {
            InitializeComponent();

            ftp.Username = Properties.Settings.Default["Username"].ToString();
            ftp.Hostname = Properties.Settings.Default["Host"].ToString();
            ftp.Password = Properties.Settings.Default["Password"].ToString();

            if (ftp != null)
            {
                List<string> dirs = ftp.ListDirectory(ftp.CurrentDirectory);
                foreach (string d in dirs)
                {
                    if(!d.Contains("."))
                        FtpTreeView.Items.Add(d);
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (FtpTreeView.SelectedItem != null)
            {
                Properties.Settings.Default.DestinationPath = FtpTreeView.SelectedItem.ToString();
                Properties.Settings.Default.Save();
            }
            this.Close();
        }

    }
}
