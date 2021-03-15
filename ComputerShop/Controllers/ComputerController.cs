using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComputerShop.Context;
using ComputerShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using ComputerShop.Stock.ApiClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;

namespace ComputerShop.Controllers
{
    [Route("/computers/{action}")]
    public class ComputerController : Controller
    {
        private readonly ComputerShopContext _context;
        private readonly IApiClient _apiClient;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ComputerController(ComputerShopContext context, IApiClient apiClient,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _apiClient = apiClient;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Products
        public async Task<IActionResult> Index(string category)
        {
            var products = await _context.Computer.Include(p => p.Category).Where(p => p.Category.Name == category)
                .ToListAsync();

            ViewBag.CategoryName = category;

            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Computer.FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            //StockItem stockItem = await _apiClient.ApiStockGetAsync(product.Id);

            //ViewBag.AmountInStock = stockItem.AmountInStock;

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _context.Category.ToListAsync(), "Id", "Name");

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,CategoryId")] Computer product,
            int amountInStock, [FromForm(Name = "imageFile")] IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                string extension = Path.GetExtension(imageFile.FileName);

                bool isImage = extension == ".jpg" || extension == ".jpeg" || extension == ".png";

                if (imageFile != null)
                {
                    if (isImage)
                    {
                        string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + imageFile.FileName;
                        string filePath = Path.Combine(uploadFolder, uniqueFileName);
                        imageFile.CopyTo(new FileStream(filePath, FileMode.Create));

                        product.Image = uniqueFileName;
                    }
                    else
                    {
                        ViewData["ErrorMessage"] = "Image file must have .jpg, .jpeg or .png file extension";

                        return View(product);
                    }
                }
                _context.Add(product);
                await _context.SaveChangesAsync();

                //StockItem stockItem = new StockItem()
                //{
                //    ProductId = product.Id,
                //    AmountInStock = amountInStock
                //};

                //await _apiClient.ApiStockPostAsync(stockItem);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Computer.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            //StockItem stockItem = await _apiClient.ApiStockGetAsync(product.Id);

            ViewData["CategoryId"] = new SelectList(await _context.Category.ToListAsync(), "Id", "Name");
            //ViewData["AmountInStock"] = stockItem.AmountInStock;

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,CategoryId")] Computer product,
            int amountInStock)
        {
            //if (id != product.Id)
            //{
            //    return NotFound();
            //}

            //StockItem stockItem = await _apiClient.ApiStockGetAsync(product.Id);

            if (ModelState.IsValid)
            {
                try
                {
                    //stockItem.AmountInStock = amountInStock;
                    //await _apiClient.ApiStockPutAsync(stockItem.Id, stockItem);

                    _context.Update(product);
                    _context.Entry(product).Property("Image").IsModified = false;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { category = "Laptops" });
            }


            ViewData["CategoryId"] = new SelectList(await _context.Category.ToListAsync(), "Id", "Name");
            //ViewData["AmountInStock"] = stockItem.AmountInStock;

            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Computer.Include(p => p.Category).FirstOrDefaultAsync(m => m.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            //StockItem stockItem = await _apiClient.ApiStockGetAsync(product.Id);
            //ViewData["AmountInStock"] = stockItem.AmountInStock;

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Computer.FindAsync(id);
            
            if (product.Image != null)
            {
                string imageFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                string imagePath = Path.Combine(imageFolder, product.Image);

                FileInfo fileInfo = new FileInfo(imagePath);

                System.IO.File.Delete(imagePath);

                fileInfo.Delete();
            }

            //await _apiClient.ApiStockDeleteAsync(product.Id);

            //_context.Product.Remove(product);
            
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(string id)
        {
            return _context.Computer.Any(e => e.Id == id);
        }
    }
}
