using Highway.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ogsysCRM.Models
{
    public class CustomersService
    {
        private readonly IRepository _repository;

        public CustomersService(IRepository repository)
        {
            _repository = repository;
        }

        public void AddCustomer(Customer customer)
        {
            _repository.Context.Add(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            _repository.Context.Remove(customer);
        }

        public IEnumerable<Customer> GetCustomerByLastName(string p)
        {
            return _repository.Find(new CustomersByName(p));
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _repository.Find(new AllCustomers());
        }

        public class CustomersByName : Query<Customer>
        {
            public CustomersByName(string name)
            {
                ContextQuery = c => c.AsQueryable<Customer>().Where(x => x.LastName == name);
            }
        }

        public class AllCustomers : Query<Customer>
        {
            public AllCustomers()
            {
                ContextQuery = c => c.AsQueryable<Customer>();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            _repository.Context.Update(customer);
        }
    }
}
