using System.Collections.Generic;
using System.Linq;
using Starveler.Common.Entities;
using Starveler.Infrastructure.DataAccess;
using Starveler.Infrastructure.Repositories.Interfaces;

namespace Starveler.Infrastructure.Repositories
{
    public class AddressRepository : IRepository<Address>
    {
        private StarvelerContext _context;
        
        public  AddressRepository(StarvelerContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public void Add(Address entity)
        {
            _context.Addresses.Add(entity);
            _context.SaveChanges();
        }

        public IList<Address> GetAll()
        {
            return _context.Addresses.ToList();
        }

        public Address GetById(int id)
        {
            return _context.Addresses.Where(x=>x.Id.Equals(id)).FirstOrDefault();
        }
    }
}