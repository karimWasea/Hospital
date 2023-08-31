using Microsoft.AspNetCore.Identity.UI.Services;

namespace hospitalUtilities
{
    public class Emailsender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}