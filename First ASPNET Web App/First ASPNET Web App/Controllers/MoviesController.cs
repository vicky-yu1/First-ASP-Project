using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using First_ASPNET_Web_App.Models;
using First_ASPNET_Web_App.ViewModels;

namespace First_ASPNET_Web_App.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie/Random
        public ActionResult Random()
        {
            // Create instance of movie model
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" },
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            // render movie model; View is just a helper method inherited from the base controller (Controller) class
            // where does movie object go in viewresult?
            // var viewResult = new ViewResult(); //create an instance of result
            // viewResult.ViewData.Model // ViewData is a ViewData dict, movie object passed into View below will be assigned to Model property
            // method 1:
            return View(viewModel);
            // method 2:
            // return new ViewResult();
        }
        public ActionResult Edit(int movieId)
        {
            return Content("id=" + movieId); //won't work for URL embed b/c default route is /{id} in RouteConfig.cs; must change that
        }
        // when we navigate to movies
        //image we'll return a view w/ list of movies from database
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            // if pageIndex not specified, default is page 1
            // if sortBy is not specified, we sort mobies by their name
            // to make parameter optional, make it nullible by adding ? after the data type
            // string in C# is a reference type and is alr. nullable
            if (!pageIndex.HasValue) // if parameter doesn't have value, initialize to 1
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
        // Apply the route attribute
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")] //pass URL template
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}