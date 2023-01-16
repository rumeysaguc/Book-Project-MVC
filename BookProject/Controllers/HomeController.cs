using Microsoft.AspNetCore.Mvc;

namespace BookProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.exp = TempData["MESSAGE"].ToString();
            return View();
        }
    }
}
