using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok( await _service.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Order order)
        {
            await _service.Add(order);
            _orderReceivedEventDispatcher.Dispatch(new OrderReceivedEvent());
            return Ok();
        }
    }
}