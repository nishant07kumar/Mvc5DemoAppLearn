using Mvc5DemoAppLearn.Models;
using Mvc5DemoAppLearn.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace Mvc5DemoAppLearn.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies



        private MyDBContext _myDBContext;
        public MoviesController()
        {
            _myDBContext = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _myDBContext.Dispose();
        }

        public ActionResult Movies()
        {
            var lstMovies = _myDBContext.Movies.Include(tt => tt.Genre);
            return View(lstMovies);
        }

        public ActionResult MovieDetails(int movieId)
        {
            var lstMovies = _myDBContext.Movies.Include(tt => tt.Genre).FirstOrDefault(tt => tt.Id == movieId);
            return View(lstMovies);
        }

        public ActionResult MovieForm()
        {
            var _genre = _myDBContext.Genre.ToList();
            var _movieFormViewModel = new MovieFormViewModel
            {
                Genre = _genre
            };
            return View(_movieFormViewModel);
        }

        public ActionResult EditMovie(int? movieId)
        {
            var lstMovie = _myDBContext.Movies.FirstOrDefault(t => t.Id == movieId);

            if (lstMovie == null)
                return HttpNotFound();

            var movieFormViewModel = new MovieFormViewModel
            {
                Movies = lstMovie,
                Genre = _myDBContext.Genre.ToList()
            };

            return View("MovieForm", movieFormViewModel);

        }

        public ActionResult SaveMovie(MovieFormViewModel movie)
        {
            if (movie.Movies.Id == 0)
            {
                _myDBContext.Movies.Add(movie.Movies);
            }
            else
            {
                var existingMovie = _myDBContext.Movies.Single(mov => mov.Id == movie.Movies.Id);
                existingMovie.MovieName = movie.Movies.MovieName;
                existingMovie.QuntityInStock = movie.Movies.QuntityInStock;
                existingMovie.ReleaseDate = movie.Movies.ReleaseDate;
                existingMovie.GenreID = movie.Movies.GenreID;
            }

            _myDBContext.SaveChanges();


            return RedirectToAction("Movies", "Movies");

        }
    }
}