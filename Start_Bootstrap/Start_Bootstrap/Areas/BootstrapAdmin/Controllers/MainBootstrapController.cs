using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Start_Bootstrap.DAL;
using Start_Bootstrap.Models;
using System.IO;
using System.Threading.Tasks;

namespace Start_Bootstrap.Areas.BootstrapAdmin.Controllers
{
    [Area("BootstrapAdmin")]
    public class MainBootstrapController : Controller
    {
        private readonly AppDbContext context;
        private readonly IWebHostEnvironment env;

        public MainBootstrapController(AppDbContext context,IWebHostEnvironment env)
        {
            this.context = context;
            this.env = env;
        }
        public async Task<IActionResult> Index()
        {
            MainBootstrap mainBootstrap = await context.MainBootstraps.FirstOrDefaultAsync();
            return View(mainBootstrap);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(MainBootstrap mainBootstrap)
        {
            if (!ModelState.IsValid) return View();

            if (mainBootstrap.Photo != null)
            {
                if (!mainBootstrap.Photo.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("Photo", "Please enter Photo type");
                    return View();
                }

                string fileName = mainBootstrap.Photo.FileName;
                string path = Path.Combine(env.WebRootPath,"assets","images");
                string fullPath = Path.Combine(path, fileName);

                using(FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    await mainBootstrap.Photo.CopyToAsync(stream);
                }

                mainBootstrap.LogoImage = fileName;
                await context.MainBootstraps.AddAsync(mainBootstrap);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("Photo", "Please enter Photo type");
                return View();
            }
        }

        public async Task<IActionResult> Detail(int id)
        {
            MainBootstrap main = await context.MainBootstraps.FirstOrDefaultAsync(m => m.Id == id);
            if (main == null) return NotFound();
            return View(main);
        }



        public async Task<IActionResult> Delete(int id)
        {
            MainBootstrap main = await context.MainBootstraps.FirstOrDefaultAsync(s => s.Id == id);
            if (main == null) return NotFound();
            return View(main);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteSlider(int id)
        {
            MainBootstrap main = await context.MainBootstraps.FirstOrDefaultAsync(s => s.Id == id);
            if (main == null) return NotFound();
            context.Remove(main);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            MainBootstrap mainBootstrap = await context.MainBootstraps.FirstOrDefaultAsync(s => s.Id == id);
            if (mainBootstrap == null) return NotFound();
            return View(mainBootstrap);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("Edit")]
        public async Task<IActionResult> Edit(int id,MainBootstrap mainBootstrap)
        {
            if (!ModelState.IsValid) return View();

            if (mainBootstrap.Photo != null)
            {
                if (!mainBootstrap.Photo.ContentType.Contains("image"))
                {
                    ModelState.AddModelError("Photo", "Please enter Photo type");
                    return View();
                }

                MainBootstrap existedMainBootstrap = await context.MainBootstraps.FirstOrDefaultAsync(s => s.Id == id);
                existedMainBootstrap.SubTitle = mainBootstrap.SubTitle;
                existedMainBootstrap.Icon = mainBootstrap.Icon;
                existedMainBootstrap.LogoImage = mainBootstrap.LogoImage;
                existedMainBootstrap.Title = mainBootstrap.Title;
                await context.MainBootstraps.AddAsync(mainBootstrap);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                ModelState.AddModelError("Photo", "Please enter Photo type");
                return View();
            }
        }

    }
}
