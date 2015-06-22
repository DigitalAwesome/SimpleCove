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

namespace SimpleCove
{
    /// <summary>
    /// Interaction logic for FtpSettings.xaml
    /// </summary>
    public partial class FtpSettings : Window
    {
        public FtpSettings()
        {
            InitializeComponent();
            if (!(Properties.Settings.Default.Password.Length > 0))
            {
                ShowPasswordChange();
            }
            //txtUsername.Text  = Properties.Settings.Default["Username"].ToString();
            //txtHost.Text      = Properties.Settings.Default["Host"].ToString();
            //txtPassword.Text  = Properties.Settings.Default["Password"].ToString();
        }


        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            if (txtConfirmPassword.Password == txtPassword.Password)
            {
                Properties.Settings.Default.Password = txtPassword.Password;
                Properties.Settings.Default.Save();
                Close();
            }
            else
                Xceed.Wpf.Toolkit.MessageBox.Show("Passwords do not match");

        }

        private void ChangePassword_Click(object sender, MouseButtonEventArgs e)
        {
            ShowPasswordChange();
        }
        private void ShowPasswordChange()
        {
            txtPassword.IsEnabled = true;
            lblConfirm.Visibility = Visibility.Visible;
            txtConfirmPassword.Visibility = Visibility.Visible;
            lblChangePassword.Visibility = Visibility.Hidden;
        }
    }
}
