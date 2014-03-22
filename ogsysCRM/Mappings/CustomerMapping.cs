using System;
using System.Linq;
using Highway.Data;
using ogsysCRM.Models;
using System.Data.Entity;
using System.Collections.Generic;

namespace ogsysCRM.Mappings
{
    public class CustomerMapping : IMappingConfiguration
    {
        public void ConfigureModelBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .ToTable("Customers");
        }
    }
}