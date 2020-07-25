using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RPM_DT.DB
{
    public class Movie
    {
        [BindProperty]
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

        public SqlParameter[] DBParams(bool InclPK)
        {
            SqlParameter p;

            var res = new List<SqlParameter>();

            if (InclPK)
            {
                p = new SqlParameter("Id", Id);
                res.Add(p);
            }
            
            p = new SqlParameter("Title", Title);
            res.Add(p);

            p = new SqlParameter("Genre", Genre);
            res.Add(p);

            p = new SqlParameter("Price", Price);
            res.Add(p);

            p = new SqlParameter("ReleaseDate", ReleaseDate);
            res.Add(p);

            p = new SqlParameter("Rating", Rating);
            res.Add(p);

            return res.ToArray();
        }

        public Movie()
        {

        }

        public Movie(DataRow row)
        {
            Id = (int)row["Id"];
            Title = (string)row["Title"];
            Genre = (string)row["Genre"];
            Price = (decimal)row["Price"];
            ReleaseDate = (DateTime)row["ReleaseDate"];
            Rating = (string)row["Rating"];
        }
    }

}
