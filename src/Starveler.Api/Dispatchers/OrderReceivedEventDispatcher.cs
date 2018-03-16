using Starveler.Common.Events;
using Starveler.Api.Dispatchers.Interfaces;
using RawRabbit;

namespace Starveler.Api.Dispatchers
{
    public class OrderReceivedEventDispatcher : IDispatcher<OrderReceivedEvent>
    {
        private IBusClient _client;
        public OrderReceivedEventDispatcher(IBusClient client)
        {
            _client = client;
        }
        public void Dispatch(OrderReceivedEvent @event)
        {
            _client.PublishAsync(@event);
        }
    }
}