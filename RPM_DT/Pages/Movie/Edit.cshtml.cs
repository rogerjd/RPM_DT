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
        DataTable Movie;

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
            if (Movie.Rows.Count == 0)
            {
                return NotFound();
            }
            return Page();
        }
    }
}