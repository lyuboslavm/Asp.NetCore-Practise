using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
