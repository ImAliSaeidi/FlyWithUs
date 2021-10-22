using System.Net.Mail;

namespace FlyWithUs.Hosted.Service.Tools.EmailSenders
{
    public class SendEmail
    {
        public static void Send(string to,string subject,string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient("imalisaeidi@gmail.com");
            mail.From = new MailAddress("imalisaeidi@gmail.com", "با ما پرواز کنید");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("imalisaeidi@gmail.com", "Ali.s1379");
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }
    }
}
