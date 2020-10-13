using ComputerShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.Context
{
    public class ComputerShopContext : DbContext
    {
        public ComputerShopContext(DbContextOptions<ComputerShopContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
