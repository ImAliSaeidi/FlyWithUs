using Microsoft.AspNetCore.Mvc;

namespace FlyWithUs.Hosted.Service.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        [Route("Admin/[Controller]/[Action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
