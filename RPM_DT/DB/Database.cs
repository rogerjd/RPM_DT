using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace RPM_DT.DB
{
    public class Database
    {
        private readonly IConfiguration _configuration;

        public Database(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataTable GetMovies()
        {
            //string ConnStr = _configuration.GetConnectionString("RazorPagesMovieContext");
            //SqlConnection conn = new SqlConnection(ConnStr);
            ////conn.TimeOut  set in ConnStr
            /////conn.Open();
            //SqlCommand command = new SqlCommand("uspGetMovies", conn); //("Select * from Movie", conn);
            //command.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter da = new SqlDataAdapter(command);
            //Movie = new DataTable();
            //da.Fill(Movie);
            ////conn.Close();
        }
    }
}
