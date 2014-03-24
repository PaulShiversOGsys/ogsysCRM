using Highway.Data;
using ogsysCRM.Models;
using System.Data.Entity;
using System.Linq;

namespace ogsysCRM.Queries.CustomerQueries
{
    public class CustomersByLastName : Query<Customer>
    {
        public CustomersByLastName(string name)
        {
            ContextQuery = c => c.AsQueryable<Customer>()
                .Include(x => x.Notes)
                .Include(x => x.Address)
                .Where(x => x.LastName == name);
        }
    }
}
