using ComputerShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

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

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole("Administrator"));

            modelBuilder.Entity<Category>().HasData(new[] 
            {
                new Category() { Id = 1, Name = "Laptops" },
                new Category() { Id = 2, Name = "Desktops" }
            });

            modelBuilder.Entity<Computer>().HasData(new[]
            {
                new Computer()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Lenovo IdeaPad Gaming 3 15ARH05",
                    ScreenSize = 15.6,
                    ScreenType = "FullHD IPS 60Hz",
                    CPU = "AMD Ryzen™ 5 4600H",
                    Cores = 6,
                    ClockSpeed = 3.0,
                    RAM = 8,
                    Storage = 256,
                    GPU = "NVIDIA GeForce GTX 1650 Ti 4GB",
                    Color = "Black",
                    Image = "lenovo.jpg",
                    Price = 839,
                    CategoryId = 1
                },
                new Computer()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Acer Aspire 5 A515-44-R415",
                    ScreenSize = 15.6,
                    ScreenType = "IPS Full HD",
                    CPU = "AMD Ryzen 3 4300U",
                    Cores = 4,
                    ClockSpeed = 2.7,
                    RAM = 4,
                    Storage = 256,
                    GPU = "AMD Radeon",
                    Color = "Silver",
                    Image = "acer.jpg",
                    Price = 499.99,
                    CategoryId = 1
                },
                new Computer() 
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Lenovo ThinkPadT E14 GEN 2",
                    ScreenSize = 14.0,
                    ScreenType = "Full HD",
                    CPU = "AMD Ryzen™ 3 4300U",
                    Cores = 4,
                    ClockSpeed = 2.7,
                    RAM = 8,
                    Storage = 256,
                    GPU = "AMD Radeon",
                    Color = "Black",
                    Image = "lenovo_2.jpg",
                    Price = 499.99,
                    CategoryId = 1
                },
                new Computer()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "LENOVO Gaming 3",
                    ScreenSize = 15.6,
                    ScreenType = "Full HD",
                    CPU = "Intel® Core™ i5-10300H",
                    Cores = 4,
                    ClockSpeed = 2.50,
                    RAM = 8,
                    Storage = 256,
                    GPU = "Geforce GTX 1650 4GB",
                    Color = "Blue",
                    Image = "lenovo_3.jpg",
                    Price = 688,
                    CategoryId = 1
                },
                new Computer()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "HP 250 G7",
                    ScreenSize = 15.6,
                    ScreenType = "Full HD",
                    CPU = "Intel Celeron N4000",
                    Cores = 2,
                    ClockSpeed = 1.10,
                    RAM = 4,
                    Storage = 128,
                    GPU = "Intel UHD Graphics 600",
                    Color = "Dark Grey",
                    Image = "hp.jpg",
                    Price = 394,
                    CategoryId = 1
                },
                new Computer()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Lenovo Yoga Slim 7",
                    ScreenSize = 14,
                    ScreenType = "IPS Full HD",
                    CPU = "AMD Ryzen™ 5 4500U",
                    Cores = 6,
                    ClockSpeed = 2.3,
                    RAM = 8,
                    Storage = 512,
                    GPU = "AMD Radeon",
                    Color = "Grey",
                    Image = "lenovo_4.jpg",
                    Price = 749,
                    CategoryId = 1
                },
                new Computer()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "EVOLIUCINIS i7 X8",
                    CPU = "Intel® Core™ i7-9700K",
                    Cores = 8,
                    ClockSpeed = 3.60,
                    RAM = 8,
                    Storage = 480,
                    GPU = "GeForce™ GTX 1660 Ti 6GB",
                    Color = "Black",
                    Image = "EVOLIUCINIS.jpg",
                    Price = 999.99,
                    CategoryId = 2
                },
                new Computer()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "MSI EXTREME",
                    CPU = "Intel® Core™ i9-9900K",
                    Cores = 8,
                    ClockSpeed = 3.60,
                    RAM = 16,
                    Storage = 500,
                    GPU = "MSI GEFORCE® RTX 2080 SUPER 8 GB",
                    Color = "Black",
                    Image = "MSI_EXTREME.jpg",
                    Price = 1799.99,
                    CategoryId = 2
                },
                new Computer()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "RYZEN 5 GT2",
                    CPU = "AMD Ryzen™ 5 2600",
                    Cores = 6,
                    ClockSpeed = 3.4,
                    RAM = 8,
                    Storage = 480,
                    GPU = "GeForce™ GTX 1650 4GB",
                    Color = "Black",
                    Image = "RYZEN_5_GT2.jpg",
                    Price = 499.99,
                    CategoryId = 2
                },
                new Computer()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "RYZEN 5 GTX",
                    CPU = "AMD Ryzen™ 5 2600",
                    Cores = 6,
                    ClockSpeed = 3.4,
                    RAM = 8,
                    Storage = 480,
                    GPU = "GeForce™ GTX 1660 6GB",
                    Color = "Black",
                    Image = "RYZEN_5_GTX.jpg",
                    Price = 599.99,
                    CategoryId = 2
                },
            });
        }

        public DbSet<Computer> Computer { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<CartItem> CartItem { get; set; }

        public DbSet<Order> Order { get; set; }
    }
}
