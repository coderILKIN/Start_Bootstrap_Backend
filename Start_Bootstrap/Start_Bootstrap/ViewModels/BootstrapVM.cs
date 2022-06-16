using Start_Bootstrap.Models;
using System.Collections.Generic;

namespace Start_Bootstrap.ViewModels
{
    public class BootstrapVM
    {
        public MainBootstrap MainBootstraps { get; set; }

        public List<Portfolio> Portfolios { get; set; }

        public About Abouts { get; set; }

        public List<Size> Sizes{ get; set; }
    }
}
