using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace RPM_DT.Pages.Movie
{
    public class EditModel : PageModel
    {
        IConfiguration _configuration;
        
        //public DataTable Movie;

        [BindProperty]
        public DB.Movie Movie { get; set; }

        public EditModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ActionResult OnGet(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            Movie = DB.Database.GetMovie(_configuration, Id.Value);
            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var res = DB.Database.EditMovie(_configuration, Movie);
                if (res == 1)
                {
                    return RedirectToPage("/Movie/Index");
                }
                else
                {
                    ViewData["err"] = "Error occurred use color";
                    return Page();
                }
            }
            return Page();
        }
    }
}