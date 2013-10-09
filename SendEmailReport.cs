using System;
using System.Net;
using System.Net.Mail;

namespace MikrotikSSHBackup
{
    class SendEmailReport
    {
        public void SendEmail(string textMessage)
        {   
            SmtpClient Smtp_Client = new SmtpClient(EmailStatic.EmailServer, Convert.ToInt32(EmailStatic.EmailPort));
            Smtp_Client.Credentials = new NetworkCredential(EmailStatic.EmailUser, EmailStatic.EmailPassowrd);
            
            Smtp_Client.EnableSsl = EmailStatic.EnableEmailSSL;
                        
            MailMessage Message = new MailMessage();
            Message.From = new MailAddress(EmailStatic.EmailUser);
            Message.To.Add(new MailAddress(EmailStatic.EmailAddress));
            Message.Subject = "MikrotikSSHBackup Report";
            Message.Body = textMessage;
            
            Smtp_Client.Send(Message);
        }
    }
}
