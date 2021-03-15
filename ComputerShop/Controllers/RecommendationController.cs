using Microsoft.AspNetCore.Mvc;

namespace ComputerShop.Controllers
{
    [Route("/recommender/{action}")]
    public class RecommendationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
