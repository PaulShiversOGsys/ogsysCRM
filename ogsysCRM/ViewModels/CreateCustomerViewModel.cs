using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ogsysCRM.ViewModels
{
    public class CreateCustomerViewModel : CustomerViewModel
    {
        [Required]
        [Display(Name = "Street")]
        public string Street { get; set; }
        
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Display(Name = "Use Email for Gravitar")]
        public bool UseEmailForGravatar { get; set; }
    }
}