using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace RPM_DT.Pages
{
    public class MoviesModel : PageModel
    {
        private readonly IConfiguration _configuration;

        public List<DB.Movie> Movies { get; set; }

        public MoviesModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            Movies = DB.Database.GetMovies(_configuration);
            Movies.Sort((a, b) => a.Title.CompareTo(b.Title));
        }
    }
}