using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComputerShop.Context;
using ComputerShop.Models;
using ComputerShop.Helpers;

namespace ComputerShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ComputerShopContext _context;

        public CartController(ComputerShopContext context)
        {
            _context = context;
        }

        // GET: api/Cart
        public IActionResult Index()
        {
            return View(SessionHelper.ReadFromSession<List<CartItem>>(HttpContext.Session, "cart"));
        }

        public async Task<IActionResult> AddToCart(int id, int quantity)
        {
            var product = await _context.Products.FindAsync(id);

            if (SessionHelper.ReadFromSession<List<CartItem>>(HttpContext.Session, "cart") == null)
            {
                List<CartItem> cart = new List<CartItem>();
                cart.Add(new CartItem()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Image = product.Image,
                    Price = product.Price,
                    Quantity = quantity
                });

                SessionHelper.WriteToSession(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<CartItem> cart = SessionHelper.ReadFromSession<List<CartItem>>(HttpContext.Session, "cart");

                int index = exits(id, cart);

                if (index == -1)
                {
                    cart.Add(new CartItem()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Image = product.Image,
                        Price = product.Price,
                        Quantity = quantity
                    });
                }
                else
                {
                    cart[index].Quantity++;
                }

                SessionHelper.WriteToSession(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index", "Products");
        }

        // POST: api/Cart
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        private int exits(int id, List<CartItem> cart)
        {
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Id == id)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
