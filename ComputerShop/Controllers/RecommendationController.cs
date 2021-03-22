using ComputerShop.Context;
using ComputerShop.Models;
using ComputerShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.Controllers
{
    [Route("/recommender/{action}")]
    public class RecommendationController : Controller
    {
        private readonly ComputerShopContext _context;

        public RecommendationController(ComputerShopContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync()
        {
            RecommendationViewModel recommendationViewModel = new RecommendationViewModel();
            recommendationViewModel.RecommendedComputer = null;

            ViewData["CategoryId"] = new SelectList(await _context.Category.ToListAsync(), "Id", "Name");

            return View(recommendationViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RecommendationViewModel recommendationViewModel)
        {
            if (ModelState.IsValid)
            {
                Computer requestedComputer = recommendationViewModel.RequestedComputer;

                int requestedCores = recommendationViewModel.CoresNotImportant ? 0 : requestedComputer.Cores;
                double requestedCpuClockSpeed = recommendationViewModel.ClockSpeedNotImportant ? 0 : requestedComputer.ClockSpeed;
                int requestedRAM = recommendationViewModel.RAMNotImportant ? 0 : requestedComputer.RAM;
                int requestedStorage = recommendationViewModel.StorageNotImportant ? 0 : requestedComputer.Storage;
                double requestedPrice = recommendationViewModel.PriceNotImportant ? 0 : requestedComputer.Price;

                double coresPriority = recommendationViewModel.CoresNotImportant ? 0 : recommendationViewModel.CorePriority;
                double clockSpeedPriority = recommendationViewModel.ClockSpeedNotImportant ? 0 : recommendationViewModel.ClockSpeedPriority;
                double ramPriority = recommendationViewModel.RAMNotImportant ? 0 : recommendationViewModel.RAMPriority;
                double storagePriority = recommendationViewModel.StorageNotImportant ? 0 : recommendationViewModel.StoragePriority;
                double pricePriority = recommendationViewModel.PriceNotImportant ? 0 : recommendationViewModel.PricePriority;

                IList<Computer> computers = await _context.Computer
                                                          .Where(c => c.CategoryId == requestedComputer.CategoryId)
                                                          .ToListAsync();

                IDictionary<double, Computer> offers = new Dictionary<double, Computer>();

                foreach (Computer computer in computers)
                {
                    double distance = Math.Sqrt(coresPriority * Math.Pow(requestedCores - computer.Cores, 2)
                        + clockSpeedPriority * Math.Pow(requestedCpuClockSpeed - computer.ClockSpeed, 2)
                        + ramPriority * Math.Pow(requestedRAM - computer.RAM, 2)
                        + storagePriority * Math.Pow(requestedStorage - computer.Storage, 2)
                        + pricePriority * Math.Pow(requestedPrice - computer.Price, 2));

                    offers.Add(distance, computer);
                }

                IOrderedEnumerable<KeyValuePair<double, Computer>> sortedOffers = offers.OrderBy(key => key.Key);

                Computer bestOffer = sortedOffers.FirstOrDefault().Value;
                bestOffer.Category = _context.Category.Where(c => c.Id == bestOffer.CategoryId).FirstOrDefault();

                recommendationViewModel.RecommendedComputer = bestOffer;
            }

            ViewData["CategoryId"] = new SelectList(await _context.Category.ToListAsync(), "Id", "Name");

            return View(recommendationViewModel);
        }
    }
}
