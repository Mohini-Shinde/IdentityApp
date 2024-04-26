using Mailjet.Client;
using Mailjet.Client.TransactionalEmails;
using Microsoft.Extensions.Configuration;
using PlayerAPI.DTOs.Account;
using System;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Threading.Tasks;

namespace PlayerAPI.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }
        //public async Task<bool> SendEmailAsync(EmailSendDto emailSend)
        //{
        //    MailjetClient client = new MailjetClient(_config["MailJet:ApiKey"], _config["MailJet:SecretKey"]);
        //    var email =new TransactionalEmailBuilder()
        //        .WithFrom(new SendContact(_config["Email:From"], _config["Email:ApplicationName"]))
        //        .WithSubject(emailSend.Subject)
        //        .WithHtmlPart(emailSend.Body)
        //        .WithTo(new SendContact(emailSend.To))
        //        .Build();
        //    var response = await client.SendTransactionalEmailAsync(email);
        //    if(response.Messages != null)
        //    {
        //        if (response.Messages[0].Status == "success")
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        public async Task<bool> SendEmailAsync(EmailSendDto emailSend)
        {
            try
            {
                var client = new SmtpClient("smtp-mail.outlook.com", 587)
                {
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_config["SMTP:Username"], _config["SMTP:Password"],"outlook.com")
                };
                var message = new MailMessage(from: _config["SMTP:Username"],
                    to: emailSend.To, subject: emailSend.Subject, body: emailSend.Body
                    );
                message.IsBodyHtml = true;
                await client.SendMailAsync(message);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
