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
            context.Configuration.LazyLoadingEnabled = false;
            context.Configuration.ProxyCreationEnabled = false;
            context.Configuration.AttachEntity(new IdentityDbContext<ApplicationUser>());
        }
    }
}
