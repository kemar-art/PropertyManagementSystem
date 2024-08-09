using Application.Contracts.Email;
using FluentValidation;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Persistence.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task VerificationEmail(string to, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["MailSettings:Mail"]));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = "Verification Email from [THE COMPANY NAME]";

            BodyBuilder bodyBuilder = new();

            //read the template
            string htmlBody = await File.ReadAllTextAsync("emailverification.html");

            htmlBody = htmlBody.Replace("{{body}}", body);

            bodyBuilder.HtmlBody = htmlBody;

            email.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_configuration["MailSettings:Host"], Convert.ToInt32(_configuration["MailSettings:Port"]), SecureSocketOptions.StartTls); ;
                smtp.Authenticate(_configuration["MailSettings:Mail"], _configuration["MailSettings:Password"]);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
        }

        public async Task JobAlretEmail(string to, string acceptUrl, string rejectUrl)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["MailSettings:Mail"]));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = "Job Alert Email from [THE COMPANY NAME]";

            BodyBuilder bodyBuilder = new();

            //read the template
            string htmlBody = await File.ReadAllTextAsync("emailjobalert.html");

            htmlBody = htmlBody.Replace("{{acceptUrl}}", acceptUrl)
                               .Replace("{{rejectUrl}}", rejectUrl);

            bodyBuilder.HtmlBody = htmlBody;


            email.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_configuration["MailSettings:Host"], Convert.ToInt32(_configuration["MailSettings:Port"]), SecureSocketOptions.StartTls); ;
                smtp.Authenticate(_configuration["MailSettings:Mail"], _configuration["MailSettings:Password"]);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
        }

        public async Task PasswordGeneratorEmail(string to, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["MailSettings:Mail"]));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = "Password Email from [THE COMPANY NAME]";

            BodyBuilder bodyBuilder = new BodyBuilder();

            //read the template
            string htmlBody = await File.ReadAllTextAsync("emailpassword.html");

            htmlBody = htmlBody.Replace("{{body}}", body);

            bodyBuilder.HtmlBody = htmlBody;

            email.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_configuration["MailSettings:Host"], Convert.ToInt32(_configuration["MailSettings:Port"]), SecureSocketOptions.StartTls); ;
                smtp.Authenticate(_configuration["MailSettings:Mail"], _configuration["MailSettings:Password"]);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
        }

        public async Task PasswordResetEmailAsync(string to, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["MailSettings:Mail"]));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = "Password Reset Email from [THE COMPANY NAME]";

            BodyBuilder bodyBuilder = new BodyBuilder();

            //read the template
            string htmlBody = await File.ReadAllTextAsync("emailpasswordreset1.html");

            htmlBody = htmlBody.Replace("{{body}}", body);

            bodyBuilder.HtmlBody = htmlBody;

            email.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_configuration["MailSettings:Host"], Convert.ToInt32(_configuration["MailSettings:Port"]), SecureSocketOptions.StartTls); ;
                smtp.Authenticate(_configuration["MailSettings:Mail"], _configuration["MailSettings:Password"]);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
        }

        public async Task ExternalPasswordResetEmailAsync(string to, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["MailSettings:Mail"]));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = "Password Reset Email from [THE COMPANY NAME]";

            BodyBuilder bodyBuilder = new BodyBuilder();

            //read the template
            string htmlBody = await File.ReadAllTextAsync("externalemailpasswordreset.html");

            htmlBody = htmlBody.Replace("{{body}}", body);

            bodyBuilder.HtmlBody = htmlBody;

            email.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_configuration["MailSettings:Host"], Convert.ToInt32(_configuration["MailSettings:Port"]), SecureSocketOptions.StartTls); ;
                smtp.Authenticate(_configuration["MailSettings:Mail"], _configuration["MailSettings:Password"]);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
        }

       

    }
}
