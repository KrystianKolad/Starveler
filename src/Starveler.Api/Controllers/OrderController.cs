using Microsoft.AspNetCore.Mvc;
using Starveler.Common.Entities;
using Starveler.Infrastructure.Services.Interfaces;

namespace Starveler.Api.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("[action]")]
        public void Add([FromBody]Order order)
        {
            _service.Add(order);
        }
    }
}