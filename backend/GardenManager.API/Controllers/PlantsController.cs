using Microsoft.AspNetCore.Mvc;

namespace GardenManager.API.Controllers
{
    public class PlantsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
