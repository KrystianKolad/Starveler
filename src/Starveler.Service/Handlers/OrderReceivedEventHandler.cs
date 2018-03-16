using MimeKit;
using Starveler.Common.Events;
using Starveler.Service.Handlers.Interfaces;
using Starveler.Service.Helpers.Interfaces;

namespace Starveler.Service.Handlers
{
    public class OrderReceivedEventHandler : IEventHandler<OrderReceivedEvent>
    {
        private IEmailHelper _emailHelper;
        public OrderReceivedEventHandler(IEmailHelper emailHelper)
        {
            _emailHelper = emailHelper;
        }
        public async Task Handle(OrderReceivedEvent @event)
        {
            var messageToSend = new MimeMessage();

            messageToSend.From.Add(new MailboxAddress("Order", "Orders@starveler.com"));
            messageToSend.Subject = "Order Received";
            messageToSend.Body = new TextPart("plain") { Text = "You have new order" };

            await _emailHelper.Send(messageToSend);
        }
    }
}