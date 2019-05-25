using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc5DemoAppLearn.Models;

namespace Mvc5DemoAppLearn.ViewModels
{
    public class CustomerFormViewModel
    {

        public IEnumerable<MembershipTypes> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}