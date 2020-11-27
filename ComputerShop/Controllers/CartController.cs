using System;
using System.Collections.Generic;
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
                newCartItem.Total = Math.Round(newCartItem.Price * newCartItem.Quantity, 2, MidpointRounding.ToZero);

                cart.Add(newCartItem);

                SessionHelper.WriteToSession(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<CartItem> cart = SessionHelper.ReadFromSession<List<CartItem>>(HttpContext.Session, "cart");

                int index = exists(id, cart);

                if (index == -1)
                {
                    cart.Add(new CartItem()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Image = product.Image,
                        Price = product.Price,
                        Quantity = quantity,
                        Total = Math.Round(product.Price * quantity, 2, MidpointRounding.ToZero)
                    });
                }
                else
                {
                    cart[index].Quantity++;
                    cart[index].Total = Math.Round(cart[index].Price * cart[index].Quantity, 2, 
                        MidpointRounding.ToZero);
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
                    item.Total = Math.Round(item.Price * item.Quantity, 2, MidpointRounding.ToZero);
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
                        item.Total = Math.Round(item.Price * item.Quantity, 2, MidpointRounding.ToZero);
                    }
                });
            }

            SessionHelper.WriteToSession(HttpContext.Session, "cart", cart);

            return RedirectToAction(nameof(Index));
        }

        private int exists(int id, List<CartItem> cart)
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
