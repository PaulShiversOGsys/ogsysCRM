using System;
using System.Linq;
using Highway.Data;
using System.Collections.Generic;
using ogsysCRM.Models;
using System.Data.Entity;

namespace ogsysCRM.Queries.CustomerQueries
{
    public class CustomerById : Scalar<Customer>
    {
        public CustomerById(int id)
        {
            ContextQuery = c => c.AsQueryable<Customer>()
                .Include(x => x.Notes.Select(y => y.User))
                .Include(x => x.Address)
                .Single(x => x.Id == id);
        }
    }
}
