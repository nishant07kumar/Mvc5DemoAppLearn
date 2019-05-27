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
        public ActionResult Index()
        {
            return RedirectToAction("Movies", "Movies");
        }


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


        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult SaveMovie(MovieFormViewModel movieForm)
        {

            if (!ModelState.IsValid)
            {
                var movieFormViewModel = new MovieFormViewModel
                {
                    Movies = movieForm.Movies,
                    Genre = _myDBContext.Genre.ToList()

                };
                return View("MovieForm", movieFormViewModel);
            }
            if (movieForm.Movies.Id == 0)
            {
                _myDBContext.Movies.Add(movieForm.Movies);
            }
            else
            {
                var existingMovie = _myDBContext.Movies.Single(mov => mov.Id == movieForm.Movies.Id);
                existingMovie.MovieName = movieForm.Movies.MovieName;
                existingMovie.QuntityInStock = movieForm.Movies.QuntityInStock;
                existingMovie.ReleaseDate = movieForm.Movies.ReleaseDate;
                existingMovie.GenreID = movieForm.Movies.GenreID;
            }

            _myDBContext.SaveChanges();


            return RedirectToAction("Movies", "Movies");

        }
    }
}