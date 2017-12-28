using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MailManager
{
    public class Model : INotifyPropertyChanged
    {


        public List<string> Folders
        {
            get
            {
                return _folders;
            }
            set
            {
                _folders = value;
                OnChanged("Folders");
            }
        }

        public List<string> MailList
        {
            get
            {
                return _mailList;
            }
            set
            {
                _mailList = value;
                OnChanged("MailList");
            }
        }

        public List<string> UserList
        {
            get
            {
                return _userList;
            }
            set
            {
                _userList = value;
                OnChanged("UserList");
            }
        }

        public string CurrentUserAddr
        {
            get
            {
                return _currentUserAddr;
            }
            set
            {
                _currentUserAddr = value;
                OnChanged("CurrentUserAddr");
            }
        }


        private List<string> _mailList = null;
        private List<string> _folders = null;
        private List<string> _userList = null;
        private string _currentUserAddr = null;
        public Model()
        {
            _mailList = new List<string>();
            _folders = new List<string>();
            _userList = new List<string>();
            _currentUserAddr = string.Empty;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
