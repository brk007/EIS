using Microsoft.AspNetCore.Mvc;

namespace EISS.Controllers
{
    public class HomeController : Controller
    {
            public IActionResult Index()
            {
                return View();
            }
    }
}

