using estudosabado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace estudosabado.Controllers.api
{
    public class MoviesAPIController : ApiController
    {
        private DataContext dataContext;

        public MoviesAPIController()
        {
            dataContext = new DataContext();
        }

        // GET /api/movies
        [Route("~/api/movies")]
        public IEnumerable<Movie> GetMovies()
        {
            return dataContext.Movie.ToList();
        }

        // GET /api/movies/1
        [Route("~/api/movies/{id}")]
        public Movie GetMovies(int id)
        {
            var movie = dataContext.Movie.SingleOrDefault(x => x.Id == id);
            return movie == null ? throw new HttpResponseException(HttpStatusCode.NotFound) : movie;
        }

        // POST /api/movie/create
        [HttpPost]
        [Route("~/api/movies/create")]
        public Movie CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            dataContext.Movie.Add(movie);
            dataContext.SaveChanges();

            return movie;
        }

        // PUT /api/movie/update
        [HttpPut]
        [Route("~/api/movies/update")]
        public HttpStatusCode UpdateMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                return HttpStatusCode.BadRequest;

            var movieInDb = dataContext.Movie.SingleOrDefault(x => x.Id == id);

            if (movieInDb == null)
                return HttpStatusCode.NotFound;

            movieInDb.NameMovie = movie.NameMovie;
            movieInDb.RateMovie = movie.RateMovie;
            movieInDb.YearMovie = movie.YearMovie;

            dataContext.SaveChanges();

            return HttpStatusCode.OK;
        }

        // DELETE /api/movie/delete/1
        [HttpDelete]
        [Route("~/api/movies/delete/{id}")]
        public HttpStatusCode DeleteMovie(int id)
        {
            var movieInDb = dataContext.Movie.SingleOrDefault(x => x.Id == id);

            if (movieInDb == null)
                return HttpStatusCode.NotFound;

            dataContext.Movie.Remove(movieInDb);
            dataContext.SaveChanges();

            return HttpStatusCode.OK;
        }
    }
}
