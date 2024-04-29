// namespace Solidarize.Infraestructure.Services;

// public class EmailService
// //: IEmailService
// {
//     public void SendEmail(string To, string Subject, string BodyHTML, string? Redirect = null)
//     {
//         string elasticEmailUsername = Environment.GetEnvironmentVariable("EMAIL_USERNAME")!;
//         string elasticEmailPassword = Environment.GetEnvironmentVariable("EMAIL_PASSWORD")!;
//         string smtpServer = Environment.GetEnvironmentVariable("SMTP_SERVER")!;
//         int smtpPort = int.Parse(Environment.GetEnvironmentVariable("SMTP_PORT")!);

//         using (SmtpClient client = new SmtpClient(smtpServer))
//         {
//             client.Port = smtpPort;
//             client.Credentials = new NetworkCredential(elasticEmailUsername, elasticEmailPassword);
//             client.EnableSsl = true;

//             MailMessage mail = new MailMessage();
//             mail.From = new MailAddress(elasticEmailUsername);
//             mail.To.Add(To);
//             mail.Subject = Subject;

//             mail.IsBodyHtml = true;
//             mail.Body = BodyHTML;

//             client.Send(mail);
//         }
//     }

// }
