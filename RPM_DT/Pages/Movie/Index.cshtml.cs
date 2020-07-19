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

        public DataTable Movie { get; set; }

        public MoviesModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
            string ConnStr = _configuration.GetConnectionString("RazorPagesMovieContext");
            SqlConnection conn = new SqlConnection(ConnStr);
            //conn.TimeOut  set in ConnStr
            ///conn.Open();
            SqlCommand command = new SqlCommand("Select * from Movie", conn);
            SqlDataAdapter da = new SqlDataAdapter(command);
            Movie = new DataTable();
            da.Fill(Movie);
            //conn.Close();
        }
    }
}