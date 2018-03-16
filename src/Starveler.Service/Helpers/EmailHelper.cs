using System.Threading.Tasks;
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
        public async Task Send(MimeMessage message)
        {
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_configuration.Host, _configuration.Port, SecureSocketOptions.None).ConfigureAwait(false);
                await client.SendAsync(message).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }
}