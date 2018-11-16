using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task Add(Order order)
        {
            await _repository.Add(order);
        }

        public async Task<IList<Order>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<Order> GetById(int id)
        {
            return await _repository.GetById(id);
        }
    }
}