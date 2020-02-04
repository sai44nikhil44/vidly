using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidly.Models;

namespace vidly.Viewmodels
{
    public class RandomMovieViewModel
    {
        public movie Movie { get; set; }
        public List<Customer> Customers { get; set; }

    }
}