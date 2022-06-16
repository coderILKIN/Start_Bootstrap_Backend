using Microsoft.AspNetCore.Mvc;

namespace Start_Bootstrap.Areas.BootstrapAdmin.Controllers
{
    [Area("BootstrapAdmin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
