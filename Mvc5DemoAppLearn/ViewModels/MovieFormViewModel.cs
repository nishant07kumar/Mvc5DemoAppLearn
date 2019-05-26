using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc5DemoAppLearn.Models;

namespace Mvc5DemoAppLearn.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movies { get; set; }
        public IEnumerable<Genre> Genre { get; set; }
    }
}