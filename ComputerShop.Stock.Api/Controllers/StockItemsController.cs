using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComputerShop.Stock.Api.Context;
using ComputerShop.Stock.Api.Models;

namespace ComputerShop.Stock.Api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockItemsController : ControllerBase
    {
        private readonly ComputerShopStockApiContext _context;

        public StockItemsController(ComputerShopStockApiContext context)
        {
            _context = context;
        }

        // GET: api/StockItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockItem>>> GetStockItem()
        {
            return await _context.StockItem.ToListAsync();
        }

        // GET: api/StockItems/5
        [HttpGet("{productId}")]
        public async Task<ActionResult<StockItem>> GetStockItem(int productId)
        {
            var stockItem = await _context.StockItem.Where(si => si.ProductId == productId).FirstOrDefaultAsync();

            if (stockItem == null)
            {
                return NotFound();
            }

            return stockItem;
        }

        // PUT: api/StockItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockItem(int id, StockItem stockItem)
        {
            if (id != stockItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(stockItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StockItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<StockItem>> PostStockItem(StockItem stockItem)
        {
            _context.StockItem.Add(stockItem);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockItem", new { id = stockItem.Id }, stockItem);
        }

        // DELETE: api/StockItems/5
        [HttpDelete("{productId}")]
        public async Task<ActionResult<StockItem>> DeleteStockItem(int productId)
        {
            var stockItem = await _context.StockItem.Where(si => si.ProductId == productId).FirstOrDefaultAsync();

            if (stockItem == null)
            {
                return NotFound();
            }

            _context.StockItem.Remove(stockItem);
            await _context.SaveChangesAsync();

            return stockItem;
        }

        private bool StockItemExists(int id)
        {
            return _context.StockItem.Any(e => e.Id == id);
        }
    }
}
