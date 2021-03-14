using ComputerShop.Context;
using ComputerShop.Enums;
using ComputerShop.Helpers;
using ComputerShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ComputerShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ComputerShopContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OrderController(ComputerShopContext context, UserManager<User> userManager,
            SignInManager<User> signInManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: OrderController
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Order.Include(o => o.CartItems)
                .Where(o => o.Status != Status.Completed && o.Status != Status.Shipped).ToListAsync();

            return View(orders);
        }

        public async Task<IActionResult> IndexByUserId(string userId)
        {
            var orders = await  _context.Order.Include(o => o.CartItems).Where(o => o.UserId == userId).ToListAsync();

            return View(orders);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create()
        {
            if (_signInManager.IsSignedIn(User) == false)
            {
                return Redirect("/Identity/Account/Login");
            }

            try
            {
                string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                Order order = new Order()
                {
                    UserId = userId,
                    CartItems = SessionHelper.ReadFromSession<List<CartItem>>(HttpContext.Session, "cart"),
                    CreationDate = DateTime.Now,
                    Status = Status.AwaitingFulfillment
                };

                double orderTotal = 0;

                foreach (CartItem cartItem in order.CartItems)
                {
                    orderTotal += cartItem.Total;
                    cartItem.Id = "";
                }

                order.Total = orderTotal;
                
                _context.Order.Add(order);

                await _context.SaveChangesAsync();

                return RedirectToAction("IndexByUserId", new { userId = userId });
            }
            catch
            {
                return RedirectToAction("Index", "Cart");
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
