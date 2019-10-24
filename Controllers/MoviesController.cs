using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using APIProcessor.Dtos;
using APIProcessor.Models;
using APIProcessor.ViewModels;

namespace APIProcessor.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Movies
        public ActionResult ProcessJson()
        {
            var movie = new Movie() { Name = "Pulp Fiction" };
            return View(movie);
        }

        public ActionResult MoviesForm()
        {
            var movie = new MovieFormViewModel();
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel(movie);
            //{
            //    Genres = _context.Genres.ToList()

            //};

            return View("MoviesForm", viewModel);
        }
    }
}