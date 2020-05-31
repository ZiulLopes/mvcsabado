using estudosabado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace estudosabado.Controllers
{
    public class MovieController : Controller
    {
        private DataContext dataContext;

        public MovieController()
        {
            dataContext = new DataContext();
        }
        
        
        // GET: Movie/Index
        public ActionResult Index(decimal? topRate)
        {
            var movies = dataContext.Movie.ToList();

            if (topRate.HasValue)
            {
                movies = movies.Where(x => x.RateMovie > topRate).ToList();
            }

            return View(movies);
        }


        // GET: Movie/Edit
        public ActionResult Edit(int movieId)
        {
            var movie = dataContext.Movie.Find(movieId);
            return View(movie);
        }

        
        // GET: Movie/Create
        [Route("movies/cadastrar")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [Route("movies/cadastrar")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (!ModelState.IsValid)
                return View(movie);

            if (movie == null)
                return RedirectToAction("Create");

            dataContext.Movie.Add(movie);
            dataContext.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Movie/Random
        public ActionResult Random(int movieId, string movieName)
        {
            return View();
        }


        // GET: Movie/ByReleaseDate
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(string.Format("Ano {0}, més {1}", year, month));
        }
    }
}