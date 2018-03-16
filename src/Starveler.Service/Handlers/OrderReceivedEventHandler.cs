using Starveler.Common.Events;
using Starveler.Service.Handlers.Interfaces;

namespace Starveler.Service.Handlers
{
    public class OrderReceivedEventHandler : IEventHandler<OrderReceivedEvent>
    {
        public void Handle(OrderReceivedEvent @event)
        {
            throw new System.NotImplementedException();
        }
    }
}