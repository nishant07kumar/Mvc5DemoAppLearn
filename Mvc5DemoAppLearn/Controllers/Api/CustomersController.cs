using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mvc5DemoAppLearn.Models;
using Mvc5DemoAppLearn.Dtos;
using AutoMapper;

namespace Mvc5DemoAppLearn.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private MyDBContext _myDBContext;
        public CustomersController()
        {
            _myDBContext = new MyDBContext();
        }

        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _myDBContext.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);

        }

        public IHttpActionResult GetCustomer(int custId)
        {
            Customer customer = _myDBContext.Customers.SingleOrDefault(cust => cust.Id == custId);
            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));

        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _myDBContext.Customers.Add(customer);
            _myDBContext.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customerDto.Id), customerDto);

        }

        [HttpPut]
        public void UpdateCustomer(int custId, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var existingCustomer = _myDBContext.Customers.SingleOrDefault(cust => cust.Id == custId);


            if (existingCustomer == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Mapper.Map(customerDto, existingCustomer);

            _myDBContext.SaveChanges();

        }

        [HttpDelete]
        public void DeleteCustomer(int custId)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var existingCustomer = _myDBContext.Customers.SingleOrDefault(cust => cust.Id == custId);


            if (existingCustomer == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);


            _myDBContext.Customers.Remove(existingCustomer);
            _myDBContext.SaveChanges();

        }
    }
}

