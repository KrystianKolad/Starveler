using Microsoft.AspNetCore.Mvc;
using Starveler.Api.Dispatchers.Interfaces;
using Starveler.Common.Entities;
using Starveler.Common.Events;
using Starveler.Infrastructure.Services.Interfaces;

namespace Starveler.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private IOrderService _service;

        private IDispatcher<OrderReceivedEvent> _orderReceivedEventDispatcher;

        public OrderController(IOrderService service,IDispatcher<OrderReceivedEvent> orderReceivedEventDispatcher)
        {
            _service = service;
            _orderReceivedEventDispatcher = orderReceivedEventDispatcher;
        }

        [HttpPost]
        [Route("[action]")]
        public void Add([FromBody]Order order)
        {
            _service.Add(order);
            _orderReceivedEventDispatcher.Dispatch(new OrderReceivedEvent());
        }
    }
}