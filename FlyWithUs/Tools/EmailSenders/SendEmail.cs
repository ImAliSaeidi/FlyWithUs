using System.Net;
using System.Net.Mail;

namespace FlyWithUs.Hosted.Service.Tools.EmailSenders
{
    public class SendEmail
    {
        public static void Send(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("mail.imalisaeidi.ir");
            mail.From = new MailAddress("Info@imalisaeidi.ir", "با ما پرواز کنید");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            smtp.Port = 25;
            smtp.Credentials = new NetworkCredential("Info@imalisaeidi.ir", "18PnBgwkq_aRi6hi");
            smtp.EnableSsl = false;

            smtp.Send(mail);
        }
    }
}
