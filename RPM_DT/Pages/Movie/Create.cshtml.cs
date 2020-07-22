using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;

namespace RPM_DT.Pages.Movie
{
    public class CreateModel : PageModel
    {
        private readonly IConfiguration _configuration;

        [BindProperty]
        public string Title { get; set; }

        [BindProperty]
        public string Genre { get; set; }

        [BindProperty]
        public decimal Price { get; set; }

        [BindProperty]
        public DateTime ReleaseDate { get; set; }

        [BindProperty]
        public string Rating { get; set; }

        public CreateModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync() //[Required] string Title, string Genre, decimal Price, DateTime ReleaseDate, string Rating)
        {
            if (ModelState.IsValid)
            {
                var res = DB.Database.NewMovie(_configuration, Title, Genre, Price, ReleaseDate, Rating);
                 return RedirectToPage("/Movie/Index");
            }
            return Page();
        }
    }
}