using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc5DemoAppLearn.Models;
using System.Data.Entity;
using Mvc5DemoAppLearn.ViewModels;

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
            var lstCustomers = _myDBContext.Customers.Include(Cust => Cust.MembershipType);
            return View(lstCustomers);
        }

        public ActionResult New()
        {

            var _membershipType = _myDBContext.MembershipTypes.ToList();

            var customerFormViewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = _membershipType
            };

            return View("CustomerForm", customerFormViewModel);
        }


        public ActionResult CustomerDetails(int? custID)
        {
            var lstCustomer = _myDBContext.Customers.FirstOrDefault(t => t.Id == custID);

            if (lstCustomer == null)
                return HttpNotFound();

            return View(lstCustomer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult SaveCustomer(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var customerFormViewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _myDBContext.MembershipTypes.ToList()

                };
                return View("CustomerForm", customerFormViewModel);
            }

            if (customer.Id == 0)
            {
                _myDBContext.Customers.Add(customer);
            }
            else
            {
                var existingCustomer = _myDBContext.Customers.Single(cust => cust.Id == customer.Id);
                existingCustomer.CustomerName = customer.CustomerName;
                existingCustomer.BirthDate = customer.BirthDate;
                existingCustomer.MembershipTypeID = customer.MembershipTypeID;
                existingCustomer.IsSubscribeToNewsLetter = customer.IsSubscribeToNewsLetter;

            }
            _myDBContext.SaveChanges();

            return RedirectToAction("Customer", "Customers");
        }

        public ActionResult Edit(int? custID)
        {
            var lstCustomer = _myDBContext.Customers.FirstOrDefault(t => t.Id == custID);

            if (lstCustomer == null)
                return HttpNotFound();

            var customerFormViewModel = new CustomerFormViewModel
            {
                Customer = lstCustomer,
                MembershipTypes = _myDBContext.MembershipTypes.ToList()
            };

            return View("CustomerForm", customerFormViewModel);

        }
    }
}