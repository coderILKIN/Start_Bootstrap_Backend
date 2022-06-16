using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Start_Bootstrap.DAL;
using Start_Bootstrap.Models;
using Start_Bootstrap.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace Start_Bootstrap.Controllers
{
    public class StartBootstrapController : Controller
    {
        private readonly AppDbContext context;

        public StartBootstrapController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            BootstrapVM model = new BootstrapVM
            {
                Portfolios = await context.Portfolios.ToListAsync(),
                MainBootstraps = await context.MainBootstraps.FirstOrDefaultAsync(),
                Abouts = await context.Abouts.FirstOrDefaultAsync()
             };
            return View(model);
        }
    }
}
