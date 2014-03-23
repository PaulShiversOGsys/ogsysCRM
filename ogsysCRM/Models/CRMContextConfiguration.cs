using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using Highway.Data;
using System.Data.Entity;
using System;
namespace ogsysCRM.Models
{
    public class CRMContextConfiguration : IContextConfiguration
    {
        public void ConfigureContext(DbContext context)
        {
            context.AttachEntity(new IdentityDbContext<ApplicationUser>());
        }
    }
}
