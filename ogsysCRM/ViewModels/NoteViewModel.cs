using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ogsysCRM.ViewModels
{
    public class NoteViewModel
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        public string UserName { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
    }
}