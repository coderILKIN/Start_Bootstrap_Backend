using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Start_Bootstrap.DAL;
using Start_Bootstrap.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Start_Bootstrap.Areas.BootstrapAdmin.Controllers
{
    [Area("BootstrapAdmin")]
    public class SizeController : Controller
    {
        private readonly AppDbContext context;

        public SizeController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Size> sizes = await context.Sizes.ToListAsync();
            return View(sizes);
        }
    }
}
