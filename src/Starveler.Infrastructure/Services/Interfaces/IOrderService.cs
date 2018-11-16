using System.Collections.Generic;
using System.Threading.Tasks;
using Starveler.Common.Entities;

namespace Starveler.Infrastructure.Services.Interfaces
{
    public interface IOrderService
    {
        Task Add(Order order);
        Task<IList<Order>> GetAll();
        Task<Order> GetById(int id);
    }
}