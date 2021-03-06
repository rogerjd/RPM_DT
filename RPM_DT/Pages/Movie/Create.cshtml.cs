﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using RPM_DT;

namespace RPM_DT.Pages.Movie
{
    public class CreateModel : PageModel
    {
        private readonly IConfiguration _configuration;

        [BindProperty]
        public DB.Movie Movie { get; set; }

        /*
                [BindProperty, Required]
                public string Title { get; set; }

                [BindProperty, Required]
                public string Genre { get; set; }

                [BindProperty, Required]
                public decimal Price { get; set; }

                [BindProperty, Required]
                [DataType(DataType.Date)]
                public DateTime ReleaseDate { get; set; }

                [BindProperty, Required]
                public string Rating { get; set; }
        */

        public CreateModel(IConfiguration configuration)
        {
            _configuration = configuration;
            Movie = new DB.Movie { ReleaseDate = DateTime.Today.Date };
        }

        public void OnGet()
        {

        }

        //todo: do we need async
        public IActionResult OnPost() //[Required] string Title, string Genre, decimal Price, DateTime ReleaseDate, string Rating)
        {
            if (ModelState.IsValid)
            {
                var res = DB.Database.NewMovie(_configuration, Movie);
                return RedirectToPage("/Movie/Index");
            }
            return Page();
        }
    }
}