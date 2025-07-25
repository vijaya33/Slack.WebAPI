using Microsoft.AspNetCore.Mvc;

namespace Slack.WebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
