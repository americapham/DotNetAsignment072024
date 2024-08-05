using Bosch.eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Bosch.eCommerce.Dal
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext()
        {

        }
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BoschEComJuly24Db;Trusted_Connection=true;TrustServerCertificate=True;");
            }
            
        }
    }
}
