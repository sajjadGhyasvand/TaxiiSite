using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Mail;
namespace Taxii.Core.Senders
{
    public static class EmailSender
    {
        public static void Send(string to, string subject, string body)
        {
            var password = "";
            var myMail = "";
            var mail = new MailMessage();
            var smtpServer = new SmtpClient("");

            mail.From = new MailAddress(myMail, "تاکسی ");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            smtpServer.Port = 0;
            smtpServer.Credentials = new NetworkCredential(myMail, password);
            smtpServer.EnableSsl = false;

            smtpServer.Send(mail);
        }
    }
}
