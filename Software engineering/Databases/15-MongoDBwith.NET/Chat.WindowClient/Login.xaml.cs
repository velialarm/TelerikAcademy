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
using Chat.Models;

namespace Chat.WindowClient
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.LoginName.Focus();
        }

        private void btnClickLogin(object sender, RoutedEventArgs e)
        {
            var username = this.LoginName.Text;
            SetMainWindows(username);
        }

        private void btnClickCnacel(object sender, RoutedEventArgs e)
        {
            SetMainWindows(null);
        }

        private void SetMainWindows(string username)
        {
            this.Hide();
            var mainWindow = new MainWindow(username);
            mainWindow.Show();
            this.Close();
        }
    }
}
