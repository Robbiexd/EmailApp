using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmailApp
{
    class MailSender
    {
        private string _fromName = "Mišák";
        private string _from = "misa@hreben.com";
        private int _port = 2525;
        private string _server = "smtp.mailtrap.io";
        private string _username = "5c020b3c23f1a8";
        private string _password = "7af1753d02907c";

        public Task SendEmailAsync(string to, string subject, string msg)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_fromName, _from));
            message.To.Add(new MailboxAddress(to));
            message.Subject = subject;

            var body = new BodyBuilder();
            body.TextBody = msg;
            body.HtmlBody = "<p> <b>" + msg + "</b> </p>";
            message.Body = body.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback =
                    (s, c, h, e) => true;
                client.Connect(_server, _port,
                    MailKit.Security.SecureSocketOptions.StartTlsWhenAvailable);
                client.Authenticate(_username, _password);
                client.Send(message);
                client.Disconnect(true);
                return Task.FromResult(0);
            }
        }
    }
}
