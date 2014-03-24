using System;
using System.Linq;
using ogsysCRM.Models;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace ogsysCRM.Mappings
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        /// <summary>
        /// Initializes a new instance of the CustomerMap class.
        /// </summary>
        public AddressMap()
        {
            ToTable("Address");
        }
    }
}