using System;
using System.Linq;
using ogsysCRM.Models;
using System.Collections.Generic;
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
            HasMany(x => x.Notes)
                .WithRequired(x => x.Customer)
                .WillCascadeOnDelete(true);
        }
    }
}