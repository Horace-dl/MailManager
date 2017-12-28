using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MailManager
{
    public class UserInfo
    {
        public string User
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
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

        public override bool Equals(object obj)
        {
            bool bRet = base.Equals(obj);
            if (obj is UserInfo)
            {
                UserInfo other = obj as UserInfo;
                if (this.User == other.User)
                {
                    bRet = true;
                }
            }
            return bRet;
        }
    }
}
