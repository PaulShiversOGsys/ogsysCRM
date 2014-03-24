using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ogsysCRM.Models
{
    public class Note : Entity
    {
        public String Body { get; set; }
        public Customer Customer { get; set; }
    }
}