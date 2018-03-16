using Starveler.Common.Entities;
using Starveler.Infrastructure.Repositories.Interfaces;
using Starveler.Infrastructure.Services.Interfaces;

namespace Starveler.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private IRepository<Order> _repository;
        public OrderService(IRepository<Order> repository)
        {
            _repository = repository;
        }
        public void Add(Order order)
        {
            _repository.Add(order);
        }
    }
}