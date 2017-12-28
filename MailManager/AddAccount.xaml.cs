using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MailManager
{
    /// <summary>
    /// Interaction logic for AddAccount.xaml
    /// </summary>
    public partial class AddAccount : Window
    {
        public string User
        {
            get
            {
                return _username;
            }

        }

        public string Password
        {
            get
            {
                return _password;
            }
        }

        public string Host
        {
            get
            {
                return _host;
            }
            set
            {
                _host = value;
            }
        }

        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }

        private string _username;
        private string _password;
        private string _host;
        private int _port;

        public AddAccount()
        {
            InitializeComponent();
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {
            _username = tbUserMail.Text;
            _password = pbPasswordCtl.Password;
            _host = tbHost.Text;
            int.TryParse(tbPort.Text, out _port);
            this.DialogResult = true;
        }


    }
}
