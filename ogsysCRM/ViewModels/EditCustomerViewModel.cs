using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ogsysCRM.ViewModels
{
    public class EditCustomerViewModel : CreateCustomerViewModel
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
    }
}
