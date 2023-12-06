using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Xml;

namespace ReactApp1.Server.Models.Database
{
    public class RetailContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> Details { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Product> Products { get; set; }

        public RetailContext(DbContextOptions<RetailContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
                .Property(e => e.AddressId)
                .ValueGeneratedOnAdd();
        }
    }
}
