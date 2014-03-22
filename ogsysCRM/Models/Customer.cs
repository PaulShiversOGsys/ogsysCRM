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

        public class CustomersByName : Query<Customer>
        {
            public CustomersByName(string name)
            {
                ContextQuery = c => c.AsQueryable<Customer>().Where(x => x.LastName == name);
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            _repository.Context.Update(customer);
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarUrl { get; set; }
        public string CompanyName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}