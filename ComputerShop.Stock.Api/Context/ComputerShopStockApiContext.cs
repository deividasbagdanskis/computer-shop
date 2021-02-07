using ComputerShop.Stock.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerShop.Stock.Api.Context
{
    public class ComputerShopStockApiContext : DbContext
    {
        public ComputerShopStockApiContext(DbContextOptions<ComputerShopStockApiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StockItem>().HasData(new[]
            {
                new StockItem() { Id = 1, ProductId = 1, AmountInStock = 5 },
                new StockItem() { Id = 2, ProductId = 2, AmountInStock = 9 },
                new StockItem() { Id = 3, ProductId = 3, AmountInStock = 7 },
                new StockItem() { Id = 4, ProductId = 4, AmountInStock = 14 },
                new StockItem() { Id = 5, ProductId = 5, AmountInStock = 8 },
                new StockItem() { Id = 6, ProductId = 6, AmountInStock = 0 },
                new StockItem() { Id = 7, ProductId = 7, AmountInStock = 6 },
                new StockItem() { Id = 8, ProductId = 8, AmountInStock = 12 },
                new StockItem() { Id = 9, ProductId = 9, AmountInStock = 3 },
                new StockItem() { Id = 10, ProductId = 10, AmountInStock = 4 }
            });
        }

        public DbSet<StockItem> StockItem { get; set; }
    }
}
