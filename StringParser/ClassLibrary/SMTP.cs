namespace ClassLibrary
{
    using System.Net;
    using System.Net.Mail;

    public class SMTP
    {
        public static void SendEmail(string email, string subject, string content, string attach = null)
        {
            // hobgoblih@gmail.com
            // Terminator2020
            MailAddress from = new MailAddress("hobgoblih@gmail.com");
            MailAddress to = new MailAddress(email);
            MailMessage msg = new MailMessage(from, to);
            if (attach == null) attach = null;
            else msg.Attachments.Add(new Attachment(attach));
            msg.Subject = subject;
            msg.Body = content;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.Credentials = new NetworkCredential("");
            client.EnableSsl = true;
            client.Send(msg);
        }

    }
}
