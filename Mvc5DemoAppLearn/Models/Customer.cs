using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc5DemoAppLearn.Models
{
    public class Customer
    {

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool IsSubscribeToNewsLetter { get; set; }

        public MembershipTypes MembershipType { get; set; }

        public byte MembershipTypeID { get; set; }
    }
}