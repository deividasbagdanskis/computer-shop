using ComputerShop.Models;
using Microsoft.AspNetCore.Identity;
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

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole("Administrator"));

            modelBuilder.Entity<Category>().HasData(new[] 
            {
                new Category() { Id = 1, Name = "Laptops" },
                new Category() { Id = 2, Name = "Desktops" }
            });

            modelBuilder.Entity<Product>().HasData(new[]
            {
                new Product()
                {
                    Id = 1,
                    Name = "Lenovo IdeaPad Gaming 3 15ARH05",
                    Description = "15.6\" FullHD IPS 60Hz ekranas | AMD Ryzen™ 5 4600H | 8GB 3200 Mhz RAM | 256GB " +
                        "SSD PCIe | NVIDIA GeForce GTX 1650 Ti 4GB | Juodas | Klaviatūra su apšvietimu | 82EY004BLT",
                    Image = "lenovo.jpg",
                    Price = 839,
                    CategoryId = 1
                },
                new Product()
                {
                    Id = 2,
                    Name = "Acer Aspire 5 A515-44-R415",
                    Description = "15.6\" IPS Full HD ekranas | AMD Ryzen 3 4300U | 4 GB DDR4 RAM | 256 GB SSD | " +
                        "AMD Radeon | Windows 10 Home",
                    Image = "acer.jpg",
                    Price = 499.99,
                    CategoryId = 1
                },
                new Product() 
                {
                    Id = 3,
                    Name = "Lenovo ThinkPadT E14 GEN 2",
                    Description = "14.0\" colių Full HD ekranas | AMD Ryzen™ 3 4300U | 8 GB RAM | 256 GB SSD | DOS",
                    Image = "lenovo_2.jpg",
                    Price = 499.99,
                    CategoryId = 1
                },
                new Product()
                {
                   Id = 4,
                   Name = "LENOVO Gaming 3",
                   Description = "Intel® Core™ i5-10300H | 15.6\" colių Full HD ekranas | 8GB RAM | 256GB SSD PCIe " +
                        "| Geforce GTX 1650 4GB | 81Y400M7LT",
                   Image = "lenovo_3.jpg",
                   Price = 688,
                   CategoryId = 1
                },
                new Product()
                {
                    Id = 5,
                    Name = "HP 250 G7",
                    Description = "CPU N4000|1100 MHz|15.6\"|1366x768|RAM 4GB|DDR4|2400 MHz|SSD 128GB|Intel UHD " +
                        "Graphics 600|Integrated|ENG|DOS|Dark Grey|1.78 kg|6MP93EA",
                    Image = "hp.jpg",
                    Price = 394,
                    CategoryId = 1
                },
                new Product()
                {
                    Id = 6,
                    Name = "Lenovo Yoga Slim 7",
                    Description = "AMD Ryzen™ 5 4500U | 14\" IPS Full HD ekranas | 8GB RAM | 512GB SSD | Windows 10 " +
                        "| Pilkas | 82A2008GLT",
                    Image = "lenovo_4.jpg",
                    Price = 749,
                    CategoryId = 1
                },
                new Product()
                {
                    Id = 7,
                    Name = "EVOLIUCINIS i7 X8",
                    Description = "Intel® Core™ i7-9700K ~4.9Ghz ( Naujiena, 8-ių branduolių ) / 8GB DDR4 3000MHz / " +
                        "480 GB SSD / GeForce™ GTX 1660 Ti 6GB / USB3.1 / HDMI / 171220_n_z390",
                    Image = "EVOLIUCINIS.jpg",
                    Price = 999.99,
                    CategoryId = 2
                },
                new Product()
                {
                    Id = 8,
                    Name = "MSI EXTREME",
                    Description = "Intel® Core™ i9-9900K 3.6~5.0Ghz („CoffeeLake“) | MSI MAG Z390 TOMAHAWK | 16GB " +
                        "DDR4 | 500GB NVMe M.2 SSD (Skaitymo greitis ~3400 MB/s) | MSI GEFORCE® RTX 2080 SUPER 8 GB| " +
                        "“Powered by MSI” | 180628_s",
                    Image = "MSI_EXTREME.jpg",
                    Price = 1799.99,
                    CategoryId = 2
                },
                new Product()
                {
                    Id = 9,
                    Name = "RYZEN 5 GT2",
                    Description = "AMD Ryzen™ 5 2600 | A320 | 8GB DDR4 | 480GB SSD (Skaitymo greitis ~560 MB/s) | " +
                    "GeForce™ GTX 1650 4GB | 180991_d2_1650",
                    Image = "RYZEN_5_GT2.jpg",
                    Price = 499.99,
                    CategoryId = 2
                },
                new Product()
                {
                    Id = 10,
                    Name = "RYZEN 5 GTX",
                    Description = "AMD Ryzen™ 5 2600 | 8GB DDR4 | 480GB SSD (Skaitymo greitis ~560 MB/s) | " +
                        "GeForce™ GTX 1660 6GB | 180994_L2 ",
                    Image = "RYZEN_5_GT2.jpg",
                    Price = 599.99,
                    CategoryId = 2
                },
            });
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<CartItem> CartItem { get; set; }

        public DbSet<Order> Order { get; set; }
    }
}
