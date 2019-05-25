using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc5DemoAppLearn.Models
{
    public class MembershipTypes
    {

        public byte ID { get; set; }

        public string MembershipName { get; set; }

        public int SignupFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscoutRate { get; set; }

    }
}