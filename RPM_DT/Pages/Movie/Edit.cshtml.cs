using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RPM_DT.Pages.Movie
{
    public class EditModel : PageModel
    {
        public ActionResult OnGet(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            return Page();

            //Movie = await _context.Movie.FirstOrDefaultAsync(m => m.ID == id);

            //if (Movie == null)
            //{
            //    return NotFound();
            //}
            //return Page();
        }
    }
}