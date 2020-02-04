using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;
using System.Web.Mvc;
using vidly.Viewmodels;
using System.Data.Entity;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        private MyDbContext context;

        public MoviesController()
        {
            context = new MyDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        public ViewResult Index()
        {
            var movies = context.Movies.Include(c => c.Genres).ToList();

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = context.Movies.Include(c => c.Genres).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        /*private IEnumerable<movie> GetMovies()
        {
            return new List<movie>
            {
                new movie { Id = 1, Name = "Shrek" },
                new movie { Id = 2, Name = "Wall-e" }
            };
        }*/

        public ActionResult Random()
        {
            var movie = new movie() { Name = "svsc" };

            var customers = new List<Customer>
            {
                new Customer{ Name = "ram"},
                new Customer{Name = "hari"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);

        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:range(1,12)}")]

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


    }
}