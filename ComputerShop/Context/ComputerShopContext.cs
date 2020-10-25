using ComputerShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.Context
{
    public class ComputerShopContext : IdentityDbContext<User>
    {
        public ComputerShopContext(DbContextOptions<ComputerShopContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Category> Category { get; set; }
    }
}
