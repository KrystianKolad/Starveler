using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Starveler.Service.Configuration;
using Starveler.Service.Helpers.Interfaces;

namespace Starveler.Service.Helpers
{
    public class EmailHelper : IEmailHelper
    {
        private readonly EmailConfiguration _configuration;

        public EmailHelper(IOptions<EmailConfiguration> optionsAccessor)
        {
            _configuration = optionsAccessor.Value;
        }
        public void Send(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.ConnectAsync(_configuration.Host, _configuration.Port, SecureSocketOptions.None).ConfigureAwait(false);
                client.SendAsync(message).ConfigureAwait(false);
                client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}