using System.Net.Mail;

namespace TravelInn.Common
{
    public class EmailService : SmtpClient
    {

        public EmailService()
        {

        }

        public new void Send(MailMessage mailMessage)
        {
            // Encodings for other characters. Borrowed from LIKHAB
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

            // From
            mailMessage.From = new MailAddress("savas.erzin@gmail.com", "TravelInn IT");

            // Html
            mailMessage.IsBodyHtml = true;

            // To
            mailMessage.To.Add("savas.erzin@gmail.com");

            // Subject
            mailMessage.Subject = "Test Email";

            // Body
            mailMessage.Body = "<h2>Test Email</h2><p>Test Test</p>";

            base.Send(mailMessage);

        }
    }
}
