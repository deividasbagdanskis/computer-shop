using ComputerShop.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ComputerShop.ViewComponents
{
    public class NavbarDropdownViewComponent : ViewComponent
    {
        private readonly ComputerShopContext _context;

        public NavbarDropdownViewComponent(ComputerShopContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _context.Category.ToListAsync());
        }
    }
}
