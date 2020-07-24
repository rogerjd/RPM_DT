using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RPM_DT.DB
{
    public class Movie
    {
        public int Id { get; set; }

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
    }
}
