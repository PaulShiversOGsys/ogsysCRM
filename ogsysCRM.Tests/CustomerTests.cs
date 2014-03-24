using System.Linq;
using Highway.Data;
using NUnit.Framework;
using ogsysCRM.Models;
using ogsysCRM.Services;
using Highway.Data.Contexts;

namespace ogsysCRM.Tests
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void ShouldAddCustomer()
        {
            //arrange
            var context = new InMemoryDataContext();
            var service = new CustomersService(new Repository(context));
            var customer = new Customer()
            {
                FirstName = "Justin",
                LastName = "Patterson",
                EmailAddress = "justinpatterson@gmail.com",
                PhoneNumber = "8173076341",
            };

            //act
            service.AddCustomer(customer);

            //assert
            Assert.That(context.AsQueryable<Customer>().Count(x => x.FirstName == "Justin"), Is.EqualTo(1));
        }

        [Test]
        public void ShouldQueryCustomerLastName()
        {
            //arrange
            var customer = new Customer()
            {
                FirstName = "Justin",
                LastName = "Patterson",
                EmailAddress = "justinpatterson@gmail.com",
                PhoneNumber = "8173076341",
            };
            var context = new InMemoryDataContext();
            context.Add(customer);

            var service = new CustomersService(new Repository(context));

            //act
            var foundCustomer = service.GetCustomerByLastName("Patterson");

            //assert
            Assert.That(foundCustomer, Is.Not.Null);
            Assert.That(foundCustomer.Count(), Is.EqualTo(1));

        }

        [Test]
        public void ShouldQueryCustomerById()
        {
            //arrange
            var customer = new Customer()
            {
                FirstName = "Justin",
                LastName = "Patterson",
                EmailAddress = "justinpatterson@gmail.com",
                PhoneNumber = "8173076341",
            };
            var context = new InMemoryDataContext();
            context.Add(customer);

            var service = new CustomersService(new Repository(context));

            //act
            var foundCustomer = service.GetCustomerById(0);

            //assert
            Assert.That(foundCustomer, Is.Not.Null);

        }

        [Test]
        public void ShouldQueryAllCustomers()
        {
            //arrange
            var customer1 = new Customer()
            {
                FirstName = "Justin",
                LastName = "Patterson",
                EmailAddress = "justinpatterson@gmail.com",
                PhoneNumber = "8173076341",
            };

            var customer2 = new Customer()
            {
                FirstName = "Darth",
                LastName = "Vader",
                EmailAddress = "darthvader@gmail.com",
                PhoneNumber = "1234567890",
            };
            var context = new InMemoryDataContext();
            context.Add(customer1);
            context.Add(customer2);

            var service = new CustomersService(new Repository(context));

            //act
            var foundCustomer = service.GetAllCustomers();

            //assert
            Assert.That(foundCustomer, Is.Not.Null);
            Assert.That(foundCustomer.Count(), Is.EqualTo(2));
        }

        [Test]
        public void ShouldUpdateCustomer()
        {
            //arrange
            var customer = new Customer()
            {
                FirstName = "Justin",
                LastName = "Patterson",
                EmailAddress = "justinpatterson@gmail.com",
                PhoneNumber = "8173076341",
            };
            var context = new InMemoryDataContext();
            context.Add(customer);

            var service = new CustomersService(new Repository(context));

            //act
            customer.FirstName = "John";
            service.UpdateCustomer(customer);

            //assert
            Assert.That(context.AsQueryable<Customer>().Count(x => x.FirstName == "John"), Is.EqualTo(1));

        }

        [Test]
        public void ShouldDeleteCustomer()
        {
            //arrange
            var customer = new Customer()
            {
                FirstName = "Justin",
                LastName = "Patterson",
                EmailAddress = "justinpatterson@gmail.com",
                PhoneNumber = "8173076341",
            };
            var context = new InMemoryDataContext();
            context.Add(customer);

            var service = new CustomersService(new Repository(context));

            //act
            service.DeleteCustomer(customer);

            //assert
            Assert.That(context.AsQueryable<Customer>().Count(x => x.FirstName == "Justin"), Is.EqualTo(0));
        }
    } 
}
