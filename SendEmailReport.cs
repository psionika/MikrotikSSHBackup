using System;
using System.Net;
using System.Net.Mail;

namespace MikrotikSSHBackup
{
    class SendEmailReport
    {
        public void SendEmail(string textMessage, string Server, string Port, string User, string Password, Boolean EnableSSL, string Address)
        {   
            SmtpClient Smtp_Client = new SmtpClient(Server, Convert.ToInt32(Port))
            {
                Credentials = new NetworkCredential(User, Password),
                EnableSsl = EnableSSL
            };

            MailMessage Message = new MailMessage {From = new MailAddress(User)};

            Message.To.Add(new MailAddress(Address));
            Message.Subject = "MikrotikSSHBackup Report";
            Message.Body = textMessage;
            
            Smtp_Client.Send(Message);
        }
    }
}
