using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ogsysCRM.Models
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

    }
}