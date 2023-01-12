using Microsoft.AspNetCore.Mvc;

namespace BookProject.Controllers
{
    public class BookController : Controller
    {
        public string Index()
        {
            return "swrfefer";
        }
        public IActionResult BookList()
        {
            return View();
        }
    }
}
