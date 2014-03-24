using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ogsysCRM.ViewModels
{
    public class CustomerViewModel
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Phone(ErrorMessage = "Ivalid Phone NUmber")]
        public string PhoneNumber { get; set; }
    }
}
