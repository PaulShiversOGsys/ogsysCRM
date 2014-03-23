using System;
using System.Linq;
using Highway.Data;
using System.Collections.Generic;
using ogsysCRM.Models;

namespace ogsysCRM.Services
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
            _repository.Context.Commit();
        }

        public void DeleteCustomer(Customer customer)
        {
            _repository.Context.Remove(customer);
            _repository.Context.Commit();
        }

        public IEnumerable<Customer> GetCustomerByLastName(string p)
        {
            return _repository.Find(new CustomersByName(p));
        }

        public Customer GetCustomerById(int id)
        {
            return _repository.Find(new CustomerById(id));
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _repository.Find(new AllCustomers());
        }

        public class CustomerById : Scalar<Customer>
        {
            public CustomerById(int id)
            {
                ContextQuery = c => c.AsQueryable<Customer>().Single(x => x.Id == id);
            }
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
            _repository.Context.Commit();
        }
    }
}
