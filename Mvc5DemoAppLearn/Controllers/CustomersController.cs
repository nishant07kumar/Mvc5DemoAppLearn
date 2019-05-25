using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5DemoAppLearn.Models;
using System.Data.Entity;

namespace Mvc5DemoAppLearn.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers

        private MyDBContext _myDBContext;
        public CustomersController()
        {
            _myDBContext = new MyDBContext();

        }

        protected override void Dispose(bool disposing)
        {
            _myDBContext.Dispose();
        }
        public ActionResult Customer()
        {
            var lstCustomers = _myDBContext.Customers.Include(Cust=>Cust.MembershipType);


            return View(lstCustomers);
        }

        public ActionResult CustomerDetails(int? custID)
        {
            var lstCustomer = _myDBContext.Customers.FirstOrDefault(t => t.Id == custID);

            if (lstCustomer == null)
                return HttpNotFound();

            return View(lstCustomer);
        }

    }
}