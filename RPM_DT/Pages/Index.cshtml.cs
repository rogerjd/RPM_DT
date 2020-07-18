using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace RPM_DT.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

        public DataTable Movie { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {
            string ConnStr = _configuration.GetConnectionString("RazorPagesMovieContext");
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from Movie", conn);
            SqlDataAdapter da = new SqlDataAdapter(command);
            Movie = new DataTable();
            da.Fill(Movie);

            conn.Close();
        }
    }
}
