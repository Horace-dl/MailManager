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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;

namespace MailManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {            
            _currentModel = new Model();
            _folders = new List<string>();
            _folders.Add("Receive Box");
            _folders.Add("Sent Box");

            _currentModel.Folders = _folders;

            _mailTitleList = new List<string>();
            _mailTitleList.Add("Mail1");
            _mailTitleList.Add("Mail2");
            _currentModel.MailList = _mailTitleList;

            _UserList = new List<UserInfo>();
            //Load user info
            _currentModel.UserList.Clear();
            foreach (UserInfo sAddr in _UserList)
            {
                _currentModel.UserList.Add(sAddr.User);
            }
            this.DataContext = _currentModel;
        }

        private void lbFolders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        UserInfo _currentUser = null;
        Model _currentModel = null;
        private List<string> _folders = null;
        private List<string> _mailTitleList = null;
        private List<UserInfo> _UserList = null;

        private void btReceiveMail_Click(object sender, RoutedEventArgs e)
        {
            //var client = new POPClient();
            //client.Connect("pop.gmail.com", 995, true);
            //client.Authenticate("admin@bendytree.com", "YourPasswordHere");
            //var count = client.GetMessageCount();
            //Message message = client.GetMessage(count);
            //Console.WriteLine(message.Headers.Subject);
        }

        private void btSendMail_Click(object sender, RoutedEventArgs e)
        {
            SendMail sMail = new SendMail();
            UserInfo u = new UserInfo();
            GetCurrentUser(out u);
            if (u != _currentUser)
                _currentUser = u;
            sMail.Presenter.Sender = _currentUser;
            sMail.ShowDialog();            
        }

        private void btAddAccount_Click(object sender, RoutedEventArgs e)
        {
            AddAccount addWindow = new AddAccount();
            if (addWindow.ShowDialog() == true)
            {
                UserInfo user = new UserInfo();
                user.User = addWindow.User;
                user.Password = addWindow.Password;
                user.Host = addWindow.Host;
                user.Port = addWindow.Port;
                if (!_UserList.Contains(user))
                {
                    _currentUser = user;
                    _UserList.Add(user);
                    _currentModel.UserList.Add(user.User);
                    _currentModel.CurrentUserAddr = user.User;
                }
            }
        }

        private void cbAccountList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //_currentUser = select one
            ComboBox box = e.OriginalSource as ComboBox;
            if (box == null)
                return;
           
            foreach (UserInfo user in _UserList)
            {
                if (user.User.Equals(box.Text))
                {
                    _currentUser = user;
                }
            }
        }

        private void GetCurrentUser(out UserInfo user)
        {
            user = null;
            foreach(UserInfo u in _UserList)
            {
                if (u.User.Equals(
                _currentModel.CurrentUserAddr))
                {
                    user = u;
                    break;
                }
            }
            
        }
    }
}
