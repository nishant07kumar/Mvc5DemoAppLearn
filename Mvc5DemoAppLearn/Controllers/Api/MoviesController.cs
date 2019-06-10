using Mvc5DemoAppLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mvc5DemoAppLearn.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace Mvc5DemoAppLearn.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private MyDBContext _myDBContext;
        public MoviesController()
        {
            _myDBContext = new MyDBContext();
        }

        public IHttpActionResult GetMovies()
        {
            var movieDtos = _myDBContext.Movies.Include(mo => mo.Genre).ToList().Select(Mapper.Map<Movie, MoviesDtos>);
            return Ok(movieDtos);

        }

        public IHttpActionResult GetMovie(int movieId)
        {
            Movie movie = _myDBContext.Movies.SingleOrDefault(mov => mov.Id == movieId);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MoviesDtos>(movie));

        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDtos moviesDtos)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MoviesDtos, Movie>(moviesDtos);
            _myDBContext.Movies.Add(movie);
            _myDBContext.SaveChanges();

            moviesDtos.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + moviesDtos.Id), moviesDtos);

        }

        [HttpPut]
        public void UpdateMovie(int movieId, MoviesDtos moviesDtos)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var existingMovie = _myDBContext.Movies.SingleOrDefault(mov => mov.Id == movieId);


            if (existingMovie == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Mapper.Map(moviesDtos, existingMovie);

            _myDBContext.SaveChanges();

        }

        [HttpDelete]
        public void DeleteMovie(int movieId)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var existingMovie = _myDBContext.Movies.SingleOrDefault(mov => mov.Id == movieId);


            if (existingMovie == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            _myDBContext.Movies.Remove(existingMovie);
            _myDBContext.SaveChanges();

        }
    }
}

