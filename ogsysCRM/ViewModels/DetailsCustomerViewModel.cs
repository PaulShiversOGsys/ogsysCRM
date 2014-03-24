using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using ogsysCRM.Models;

namespace ogsysCRM.ViewModels
{
    public class DetailsCustomerViewModel : CustomerViewModel
    {
        public int Id { get; set; }
        public ICollection<NoteViewModel> Notes { get; set; }

        [Display(Name = "Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Display(Name = "")]
        [DataType(DataType.ImageUrl)]
        public string AvatarUrl { get; set; }

    }
}