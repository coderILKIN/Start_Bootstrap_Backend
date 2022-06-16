using Microsoft.EntityFrameworkCore;
using Start_Bootstrap.Models;

namespace Start_Bootstrap.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<MainBootstrap> MainBootstraps { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<About> Abouts { get; set; }

        public DbSet<Size> Sizes { get; set; }
    }
}
