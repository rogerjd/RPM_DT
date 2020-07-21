using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace RPM_DT.DB
{
    static public class Database
    {
        static private SqlCommand GetSqlCommand(IConfiguration configuration, string SPName)
        {
            string ConnStr = configuration.GetConnectionString("RazorPagesMovieContext");
            SqlConnection conn = new SqlConnection(ConnStr);

            SqlCommand command = new SqlCommand(SPName, conn); //("Select * from Movie", conn);
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        static public DataTable GetMovies(IConfiguration configuration)
        {
            SqlCommand cmd = GetSqlCommand(configuration, "MovieGet");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            return tbl;
        }
    }
}
