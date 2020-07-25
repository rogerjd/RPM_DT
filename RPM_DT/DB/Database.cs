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

        #region "Movie"
        //todo: List<Movie> ???
        static public DataTable GetMovies(IConfiguration configuration)
        {
            SqlCommand cmd = GetSqlCommand(configuration, "MoviesGet");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            return tbl;
        }

        static public Movie GetMovie(IConfiguration configuration, int id)
        {
            SqlCommand cmd = GetSqlCommand(configuration, "MovieGet");
            cmd.Parameters.AddWithValue("Id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();  
            da.Fill(tbl);
            if (tbl.Rows.Count == 0)
            {
                return null;
            }
            var m = new Movie
            {
                Id = (int)tbl.Rows[0]["Id"],
                Title = (string)tbl.Rows[0]["Title"],
                Genre = (string)tbl.Rows[0]["Genre"],
                Price = (decimal)tbl.Rows[0]["Price"],
                ReleaseDate = (DateTime)tbl.Rows[0]["Price"],
                Rating = (string)tbl.Rows[0]["Rating"]
            };
            return m;
        }

        static public int NewMovie(IConfiguration configuration, Movie movie)
        {
            SqlCommand cmd = GetSqlCommand(configuration, "MovieNew");
            cmd.Parameters.AddWithValue("Title", movie.Title);
            cmd.Parameters.AddWithValue("Genre", movie.Genre);
            cmd.Parameters.AddWithValue("ReleaseDate", movie.ReleaseDate);
            cmd.Parameters.AddWithValue("Price", movie.Price);
            cmd.Parameters.AddWithValue("Rating", movie.Rating);
            cmd.Connection.Open();
            try
            {
                int n = cmd.ExecuteNonQuery();
                return n;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }

        static public int UpdateMovie(IConfiguration configuration, Movie movie)
        {
            SqlCommand cmd = GetSqlCommand(configuration, "MovieUpdt");
            cmd.Parameters.AddWithValue("Title", movie.Title);
            cmd.Parameters.AddWithValue("Genre", movie.Genre);
            cmd.Parameters.AddWithValue("ReleaseDate", movie.ReleaseDate);
            cmd.Parameters.AddWithValue("Price", movie.Price);
            cmd.Parameters.AddWithValue("Rating", movie.Rating);
            cmd.Connection.Open();
            try
            {
                int n = cmd.ExecuteNonQuery();
                return n;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
        #endregion
    }
}
