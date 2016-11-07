using MailKit.Net.Smtp;
using MimeKit;
using UniversalMaibox.Dto;
using UniversalMaibox.Properties;

namespace UniversalMaibox.Composed
{
    public class ComposedSmtpClient
    {
        public SmtpClient Client { get; set; }
        public ComposedSmtpClient(ClientDto cd)
        {
            Construction(cd);
        }
        public ComposedSmtpClient()
        {
            Construction(null);
        }
        private void Construction(ClientDto cd)
        {
            Client = new SmtpClient { ServerCertificateValidationCallback = (s, c, h, e) => true };
            Client.AuthenticationMechanisms.Remove("XOAUTH2");
            if (cd == null)
            {
                Client.Connect(Resources.DefaultSmptHost, int.Parse(Resources.DefaultSmptPort), true);
                Client.Authenticate(Resources.DefaultLogin, Resources.DefaultPassword);
            }
            else
            {
                Client.Connect(cd.Host, cd.Port, cd.Ssl);
                Client.Authenticate(cd.Login, cd.Passwd);
            } 
        }
        public void Send(MimeMessage message)
        {
            if (Client != null)
            {
                Client.Send(message);
                Client.Disconnect(true);
            }
        }
    }
}
