using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer() {Name = "Customer 1"},
                new Customer() {Name = "Customer 2"}

            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //Incorrect approaches Too complex
            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie;

            var viewResult = new ViewResult();
            return View(viewModel);
            // return Content("Hello World");
            //return HttpNotFound();
            //return EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult Edit(int id)
        {
            return Content("id= " + id);
        }
        //movies
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if(!pageIndex.HasValue)
               pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "name";
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}