using System;
using System.Linq;
using Highway.Data;
using System.Collections.Generic;
using ogsysCRM.Models;
using System.Data.Entity;

namespace ogsysCRM.Queries.CustomerQueries
{
    public class AllCustomers : Query<Customer>
    {
        public AllCustomers()
        {
            ContextQuery = c => c.AsQueryable<Customer>()
                .Include(x => x.Notes)
                .Include(x => x.Address);
        }
    }
}
