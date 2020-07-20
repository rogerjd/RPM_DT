using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RPM_DT.Pages.Movie
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync([Required] string Title, string Genre, decimal Price, DateTime ReleaseDate, string Rating)
        {
            if (ModelState.IsValid)
            {
                return RedirectToPage("/Movie/Index");
            }
            return Page();
        }
    }
}