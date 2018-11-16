using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public async Task Add(Order entity)
        {
            await _context.Orders.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task<IList<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetById(int id)
        {
            return await _context.Orders.Where(x=>x.Id.Equals(id)).FirstOrDefaultAsync();
        }
    }
}