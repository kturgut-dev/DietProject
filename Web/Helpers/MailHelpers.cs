using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using FluentEmail.Core;
using FluentEmail.Core.Models;
using FluentEmail.Smtp;

namespace Web.Helpers
{
    public static class MailHelpers
    {
        public static async Task<bool> SendMail(string toMailAddress, string title, string bodyContent)
        {
            try
            {
                SmtpClient smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    UseDefaultCredentials = false,
                    EnableSsl = true,
                    Port = 587,
                    Credentials = new NetworkCredential("dietproject.98@gmail.com", "DietProject123")
                };

                Email.DefaultSender = new SmtpSender(smtp);
                var email = Email
                    .From("dietproject.98@gmail.com", "Diet Projesi")
                    .To(toMailAddress)
                    .Subject(title)
                    .Body(bodyContent, true);

                SendResponse result = await email.SendAsync();
                return result.Successful;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
