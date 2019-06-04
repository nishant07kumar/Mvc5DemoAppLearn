using Mvc5DemoAppLearn.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc5DemoAppLearn.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }


        [MembershipAgeValidation]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribeToNewsLetter { get; set; }

        public byte MembershipTypeID { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
    }
}