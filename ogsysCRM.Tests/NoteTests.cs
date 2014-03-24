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
            note.User = user;

            service.AddNote(note);

            //assert
            Assert.That(context.AsQueryable<Note>().Where(x => x.User.UserName == "Justin").Count(), Is.EqualTo(1));
        }

        [Test]
        public void ShouldUpdateNote()
        {
            //arrange
            var context = new InMemoryDataContext();
            const string editedBody = "edit";

            var customer = new Customer()
            {
                FirstName = "Justin",
                LastName = "Patterson",
                EmailAddress = "justinpatterson@gmail.com",
                PhoneNumber = "8173076341",
                Notes = new List<Note>()
            };

            var user = new ApplicationUser()
            {
                UserName = "Justin"
            };

            context.Add(customer);
            context.Add(user);
            context.Add(new Note()
            {
                Body = "Hello There",
                Customer = customer,
                User = user
            });

            var service = new CustomersService(new Repository(context));
            var note = context.AsQueryable<Note>().Single(x => x.Id == 0);

            //act
            note.Body = editedBody;
            service.UpdateNote(note);

            //assert
            Assert.That(context.AsQueryable<Note>().Single(x => x.User.UserName == "Justin").Body, Is.EqualTo(editedBody));
        }

        [Test]
        public void ShouldGetNoteById()
        {
            //arrange
            var context = new InMemoryDataContext();

            var customer = new Customer()
            {
                FirstName = "Justin",
                LastName = "Patterson",
                EmailAddress = "justinpatterson@gmail.com",
                PhoneNumber = "8173076341",
                Notes = new List<Note>()
            };

            var user = new ApplicationUser()
            {
                UserName = "Justin"
            };

            context.Add(customer);
            context.Add(user);
            context.Add(new Note()
            {
                Body = "Hello There",
                Customer = customer,
                User = user
            });

            var service = new CustomersService(new Repository(context));

            //act
            var note = service.NoteById(0);

            //assert
            Assert.That(context.AsQueryable<Note>().Where(x => x.User.UserName == "Justin").Count(), Is.EqualTo(1));
        }

        [Test]
        public void ShouldDeleteNote()
        {
            //arrange
            var context = new InMemoryDataContext();

           var customer = new Customer()
            {
                FirstName = "Justin",
                LastName = "Patterson",
                EmailAddress = "justinpatterson@gmail.com",
                PhoneNumber = "8173076341",
                Notes = new List<Note>()
            };

            var user = new ApplicationUser()
            {
                UserName = "Justin"
            };

            var note = new Note()
            {
                Body = "Hello There",
                Customer = customer,
                User = user
            };

            context.Add(customer);
            context.Add(user);
            context.Add(note);

            var service = new CustomersService(new Repository(context));

            //act
            service.DeleteNoteById(0);

            //assert
            Assert.That(context.AsQueryable<Note>().Where(x => x.User.UserName == "Justin").Count(), Is.EqualTo(0));
        }
    }
}
