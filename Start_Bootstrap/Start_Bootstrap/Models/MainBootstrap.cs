using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Start_Bootstrap.Models
{
    public class MainBootstrap
    {
        public int Id { get; set; }

        public string LogoImage { get; set; }

        [StringLength(maximumLength:40)]
        public string Title { get; set; }

        public string Icon { get; set; }

        [StringLength(maximumLength:100)]
        public string SubTitle { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }


    }
}
