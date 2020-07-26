﻿using System;
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
        static public List<Movie> GetMovies(IConfiguration configuration)
        {
            SqlCommand cmd = GetSqlCommand(configuration, "MoviesGet");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            da.Fill(tbl);
            var res = new List<Movie>();
            Movie m;
            foreach (DataRow row in tbl.Rows)
            {
                m = new Movie(row);
                res.Add(m);
            }
            return res;
        }

        internal static int EditMovie(IConfiguration configuration, Movie movie)
        {
            SqlCommand cmd = GetSqlCommand(configuration, "MovieUpdate");
            cmd.Parameters.AddRange(movie.DBParams(true));
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
            var m = new Movie(tbl.Rows[0]);
            return m;
        }

        static public int NewMovie(IConfiguration configuration, Movie movie)
        {
            SqlCommand cmd = GetSqlCommand(configuration, "MovieNew");
            cmd.Parameters.AddRange(movie.DBParams(false));
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
