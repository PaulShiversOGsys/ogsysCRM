using System;
using System.Linq;
using ogsysCRM.Models;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;

namespace ogsysCRM.Mappings
{
    public class UserMap : EntityTypeConfiguration<ApplicationUser>
    {

        public UserMap()
        {
            HasMany(x => x.Notes);
        }
    }
}
