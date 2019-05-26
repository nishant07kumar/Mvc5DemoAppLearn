using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mvc5DemoAppLearn.Models
{
    public class MembershipAgeValidation : ValidationAttribute

    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeID == 0 || customer.MembershipTypeID == 1)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
                return new ValidationResult("Birth Date is required Field.");

            int customerAge = DateTime.Now.Year - customer.BirthDate.Value.Year;

            return customerAge <= 18 ? new ValidationResult("Customer is not having 18 Year old to opt membership.") : ValidationResult.Success;

        }
    }
}