using Microsoft.AspNet.Identity.EntityFramework;
using ogsysCRM.Mappings;
using System.Collections.Generic;

namespace ogsysCRM.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Note> Notes { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UserMap());
        }

        public System.Data.Entity.DbSet<ogsysCRM.Models.Note> Notes { get; set; }
        public System.Data.Entity.DbSet<ogsysCRM.Models.Customer> Customers { get; set; }
    }
}