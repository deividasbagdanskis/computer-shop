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
using AutoMapper;

namespace ComputerShop.Controllers
{
    public class CartController : Controller
    {
        private readonly ComputerShopContext _context;
        private readonly IMapper _mapper;

        public CartController(ComputerShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Cart
        public IActionResult Index()
        {
            return View(SessionHelper.ReadFromSession<List<CartItem>>(HttpContext.Session, "cart"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int id, [Bind("quantity")] int quantity)
        {
            var product = await _context.Product.FindAsync(id);

            product.Category = await _context.Category.SingleAsync(c => c.Id == product.CategoryId);

            if (SessionHelper.ReadFromSession<List<CartItem>>(HttpContext.Session, "cart") == null)
            {
                List<CartItem> cart = new List<CartItem>();

                CartItem newCartItem = _mapper.Map<CartItem>(product);
                newCartItem.Quantity = quantity;

                cart.Add(newCartItem);

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
            return RedirectToAction("Index", "Product", new { category = product.Category.Name });
        }

        public IActionResult IncreaseQuantity(int id)
        {
            List<CartItem> cart = SessionHelper.ReadFromSession<List<CartItem>>(HttpContext.Session, "cart");
            
            cart.ForEach(item =>
            {
                if (item.Id == id)
                {
                    item.Quantity++;
                }
            });

            SessionHelper.WriteToSession(HttpContext.Session, "cart", cart);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult DecreaseQuantity(int id)
        {
            List<CartItem> cart = SessionHelper.ReadFromSession<List<CartItem>>(HttpContext.Session, "cart");

            CartItem cartItem = cart.Find(item => item.Id == id);

            if (cartItem.Quantity == 1)
            {
                cart.Remove(cartItem);
            }
            else
            {
                cart.ForEach(item =>
                {
                    if (item.Id == id)
                    {
                        item.Quantity--;
                    }
                });
            }

            SessionHelper.WriteToSession(HttpContext.Session, "cart", cart);

            return RedirectToAction(nameof(Index));
        }

        // POST: api/Cart
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Product.Add(product);
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
