﻿using ComputerShop.Context;
using ComputerShop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(ComputerShop.Areas.Identity.IdentityHostingStartup))]
namespace ComputerShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<ComputerShopContext>(options =>
                    options.UseSqlServer(context.Configuration.GetConnectionString("ComputerShopContext")));

                services.AddIdentity<User, IdentityRole>(options =>
                {
                    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+ ";
                    options.SignIn.RequireConfirmedAccount = true;
                    options.Password.RequireDigit = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                }).AddEntityFrameworkStores<ComputerShopContext>();

                services.AddAuthorization();
            });
        }
    }
}