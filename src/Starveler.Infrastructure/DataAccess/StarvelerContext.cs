using Microsoft.EntityFrameworkCore;
using Starveler.Common.Entities;
using Starveler.Infrastructure.Configurations;

namespace Starveler.Infrastructure.DataAccess
{
    public class StarvelerContext : DbContext
    {

        public StarvelerContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DishConfiguration());
            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }
    }
}