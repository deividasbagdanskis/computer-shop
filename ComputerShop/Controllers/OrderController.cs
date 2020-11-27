using ComputerShop.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ComputerShopContext _context;

        public OrderController(ComputerShopContext context)
        {
            _context = context;
        }

        // GET: OrderController
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: OrderController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        //public async Task<IActionResult> Create()
        //{
        //    return View();
        //}

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create()
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

        // GET: OrderController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
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
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
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
