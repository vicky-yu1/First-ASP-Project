using First_ASPNET_Web_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace First_ASPNET_Web_App.ViewModels
{
    public class RandomMovieViewModel
    {
        // View model is built specifically for a view, includes data and rules specific to that view

        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}