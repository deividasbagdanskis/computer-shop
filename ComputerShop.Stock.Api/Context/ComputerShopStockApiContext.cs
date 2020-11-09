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

        public DbSet<StockItem> StockItem { get; set; }
    }
}
