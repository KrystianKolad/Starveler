using System.Collections.Generic;
using System.Linq;
using Starveler.Common.Entities;
using Starveler.Infrastructure.DataAccess;
using Starveler.Infrastructure.Repositories.Interfaces;

namespace Starveler.Infrastructure.Repositories
{
    public class DishRepository : IRepository<Dish>
    {
        private StarvelerContext _context;
        
        public  DishRepository(StarvelerContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public void Add(Dish entity)
        {
            _context.Dishes.Add(entity);
            _context.SaveChanges();
        }

        public IList<Dish> GetAll()
        {
            return _context.Dishes.ToList();
        }

        public Dish GetById(int id)
        {
            return _context.Dishes.Where(x=>x.Id.Equals(id)).FirstOrDefault();
        }
    }
}