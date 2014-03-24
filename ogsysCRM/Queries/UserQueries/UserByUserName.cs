using System;
using System.Linq;
using Highway.Data;
using System.Collections.Generic;
using ogsysCRM.Models;
using System.Data.Entity;
using AutoMapper;

namespace ogsysCRM.Queries.UserQueries
{
    public class UserByUserName : Scalar<ApplicationUser>
    {

        public UserByUserName(string userName)
        {
            ContextQuery = c => c.AsQueryable<ApplicationUser>()
                .Include(x => x.Notes)
                .SingleOrDefault(x => x.UserName == userName);
        }
    }
}
