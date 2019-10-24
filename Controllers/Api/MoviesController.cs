using APIProcessor.Dtos;
using APIProcessor.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;


namespace APIProcessor.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }

        //GET /api/movies


        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDto>));
        }

        //POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            movieDto.DateAdded = DateTime.Now;
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            //movieDto.Id = movie.Id; //I can either update the dto with the newly created ID or map the movie to movie DTO
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), Mapper.Map<Movie, MovieDto>(movie)) ;
        }

        // DELETE api/movies/5
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int id)
        {
            var customerInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            _context.Movies.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
