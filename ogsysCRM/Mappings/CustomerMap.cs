using System;
using System.Linq;
using Highway.Data;
using ogsysCRM.Models;
using System.Data.Entity;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration;

namespace ogsysCRM.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        /// <summary>
        /// Initializes a new instance of the CustomerMap class.
        /// </summary>
        public CustomerMap()
        {
            ToTable("Customers");
        }
    }
}