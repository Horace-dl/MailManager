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
using System.Net;
using System.Net.Mail;

namespace MailManager
{
    /// <summary>
    /// Interaction logic for SendMail.xaml
    /// </summary>
    public partial class SendMail : Window
    {
        public SendPresenter Presenter
        {
            get
            {
                return _presenter;
            
            }
        }
        private SendPresenter _presenter;

        public SendMail()
        {
            InitializeComponent();
            _presenter = new SendPresenter();
            this.DataContext = _presenter;
        }

        private void btSend_Click(object sender, RoutedEventArgs e)
        {
            if (_presenter.Sender.Host.ToLower().Contains("gmail"))
            {
                SendGmail();
            }
            else if (_presenter.Sender.Host.ToLower().Contains("sina"))
            {
                SendSinaMail();
            }
        }

        private void SendGmail()
        {
            try {
                string richText = new TextRange(rtbBodyText.Document.ContentStart, rtbBodyText.Document.ContentEnd).Text;
                var message = new MailMessage(_presenter.Sender.User, _presenter.Receiver);
                message.Subject = _presenter.MailTitle; // "What Up, Dog?";
                message.Body = richText; //"Why you got ta be all up in my grill?";
                SmtpClient mailer = new SmtpClient(_presenter.Sender.Host, _presenter.Sender.Port);//"smtp.gmail.com"587
                mailer.DeliveryMethod = SmtpDeliveryMethod.Network;
                mailer.Credentials = new NetworkCredential(_presenter.Sender.User, _presenter.Sender.Password);
                mailer.EnableSsl = true;
                mailer.Send(message);
                MessageBox.Show("Mail was sent");
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("Send mail failed due to {0}", ex.Message));
            }
        }

        private void SendSinaMail()
        {
            try
            {
                string richText = new TextRange(rtbBodyText.Document.ContentStart, rtbBodyText.Document.ContentEnd).Text;
                var message = new MailMessage(_presenter.Sender.User, _presenter.Receiver);
                message.Subject = _presenter.MailTitle; // "What Up, Dog?";
                message.Body = richText; //"Why you got ta be all up in my grill?";
                SmtpClient mailer = new SmtpClient(_presenter.Sender.Host, _presenter.Sender.Port);//"smtp.gmail.com"587
                mailer.DeliveryMethod = SmtpDeliveryMethod.Network;
                mailer.Credentials = new NetworkCredential(_presenter.Sender.User, _presenter.Sender.Password);
         
                mailer.Send(message);
                MessageBox.Show("Mail was sent");
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Send mail failed due to {0}", ex.Message));
            }
        }
    }
}
