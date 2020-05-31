using Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace estudosabado.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string NameMovie { get; set; }
        public decimal RateMovie { get; set; }

        [MinMovies70years]
        public int YearMovie { get; set; }
    }
}