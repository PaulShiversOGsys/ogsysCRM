using System;
using System.Linq;
using Highway.Data;
using ogsysCRM.Models;
using System.Data.Entity;
using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ogsysCRM.Mappings
{
    public class CRMMapping : IMappingConfiguration
    {

        public void ConfigureModelBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());

            modelBuilder.Configurations.Add(new NoteMap());

            //modelBuilder
            //    .Entity<ApplicationUser>()
            //    .ToTable("ApplicationUsers");

            ////The Following from;
            ////http://stackoverflow.com/questions/19913447/user-in-entity-type-mvc5-ef6
            //modelBuilder
            //    .Entity<IdentityUserLogin>()
            //    .HasKey<string>(l => l.UserId)

            //modelBuilder
            //    .Entity<IdentityRole>()
            //    .HasKey<string>(r => r.Id)
            //    .ToTable("AspNetRoles");

            //modelBuilder
            //    .Entity<IdentityUserRole>()
            //    .HasKey(r => new { r.RoleId, r.UserId })
            //    .ToTable("AspNetUserRoles");
        }
    }
}
