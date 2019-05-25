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


        public ActionResult Movies()
        {
            var lstMovies = _myDBContext.Movies.Include(tt => tt.Genre);


            return View(lstMovies);
        }

        public ActionResult MovieDetails(int movieId)
        {
            var lstMovies = _myDBContext.Movies.Include(tt => tt.Genre).FirstOrDefault(tt=>tt.Id== movieId);


            return View(lstMovies);
        }

        public ActionResult Random()
        {



            Movie _movies = new Movie();
            _movies.MovieName = "Hulk";

            List<Customer> lstCustomers = new List<Customer> {
                new Customer{ CustomerName="Nishant"},
                new Customer{CustomerName="Apoorva"}
            };

            var randomMovieViewModel = new RandomMovieViewModel
            {
                Movie = _movies,
                Customers = lstCustomers
            };

            return View(randomMovieViewModel);
        }
    }
}