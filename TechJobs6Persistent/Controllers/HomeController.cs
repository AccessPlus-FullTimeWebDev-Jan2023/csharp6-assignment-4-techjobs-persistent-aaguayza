using Microsoft.AspNetCore.Mvc;

namespace TechJobs6Persistent.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
