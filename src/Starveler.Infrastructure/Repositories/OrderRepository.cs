using System.Collections.Generic;
using System.Linq;
using Starveler.Common.Entities;
using Starveler.Infrastructure.DataAccess;
using Starveler.Infrastructure.Repositories.Interfaces;

namespace Starveler.Infrastructure.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private StarvelerContext _context;
        
        public  OrderRepository(StarvelerContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public void Add(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }

        public IList<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders.Where(x=>x.Id.Equals(id)).FirstOrDefault();
        }
    }
}