using Microsoft.AspNetCore.Mvc;

namespace GardenManager.API.Controllers
{
    public class HealthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
