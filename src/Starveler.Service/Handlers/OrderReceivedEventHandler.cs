using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MimeKit;
using Starveler.Common.Events;
using Starveler.Service.Handlers.Interfaces;
using Starveler.Service.Helpers.Interfaces;

namespace Starveler.Service.Handlers
{
    public class OrderReceivedEventHandler : IEventHandler<OrderReceivedEvent>
    {
        private IEmailHelper _emailHelper;
        private ILogger _logger;
        public OrderReceivedEventHandler(
            IEmailHelper emailHelper,
            ILoggerFactory loggerFactory)
        {
            _emailHelper = emailHelper;
            _logger = loggerFactory.CreateLogger<OrderReceivedEventHandler>();
        }
        public async Task Handle(OrderReceivedEvent @event)
        {
            try
            {
                _logger.LogInformation("Handling Email");
                var messageToSend = new MimeMessage();

                messageToSend.From.Add(new MailboxAddress("Order", "Orders@starveler.com"));
                messageToSend.Subject = "Order Received";
                messageToSend.Body = new TextPart("plain") { Text = "You have new order" };

                await _emailHelper.Send(messageToSend);
                _logger.LogInformation("Email HandlerSuccesfully");
            }
            catch (System.Exception ex)
            {
                _logger.LogError("Email sending failed",ex);
                throw;
            }
        }
    }
}