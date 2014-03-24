using Highway.Data;
using Highway.Data.Contexts;
using NUnit.Framework;
using ogsysCRM.Models;
using ogsysCRM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ogsysCRM.Tests
{
    [TestFixture]
    class NoteTests
    {

        [Test]
        public void ShouldAddNote()
        {
            //arrange
            var note = new Note()
            {
                Body = "Hello There"
            };

            var context = new InMemoryDataContext();
            context.Add(new Customer()
                {
                    FirstName = "Justin",
                    LastName = "Patterson",
                    EmailAddress = "justinpatterson@gmail.com",
                    PhoneNumber = "8173076341",
                    Notes = new List<Note>()
                });
            context.Add(new ApplicationUser()
            {
                UserName = "Justin"
            });
            
            var service = new CustomersService(new Repository(context));

            var customer = service.GetCustomerById(0);

            var user = service.GetUserByUserName("Justin");

            //act
            note.Customer = customer;
            //note.User = user;
            service.AddNote(note);

            var justin = context.AsQueryable<Customer>().Single(x => x.FirstName == "Justin");
            var hello = context.AsQueryable<Note>();

            //assert
            Assert.That(context.AsQueryable<Customer>().Single(x => x.FirstName == "Justin").Notes.ToList().Count, Is.EqualTo(1));
        }
    }
}
