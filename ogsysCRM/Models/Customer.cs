using Highway.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ogsysCRM.Models
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarUrl { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}