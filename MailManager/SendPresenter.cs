using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace MailManager
{
    public class SendPresenter : INotifyPropertyChanged
    {

        public UserInfo Sender
        {
            get
            {
                return _sender;
            }
            set
            {
                _sender = value;
                FireChangeEvent("Sender");
            }
        }

        public string Receiver
        {
            get
            {
                return _receiver;
            }
            set
            {
                _receiver = value;
                FireChangeEvent("Receiver");
            }

        }


        public string MailTitle
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                FireChangeEvent("MailTitle");
            }
        }

        private string _receiver = string.Empty;
        private UserInfo _sender = new UserInfo();
        private string _title = string.Empty;

        public SendPresenter()
        { }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void FireChangeEvent(string name)
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
