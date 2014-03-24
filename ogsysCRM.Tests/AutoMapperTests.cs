using AutoMapper;
using NUnit.Framework;
using ogsysCRM.App_Start;
using ogsysCRM.Models;
using ogsysCRM.Utils;
using ogsysCRM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ogsysCRM.Tests
{
    [TestFixture]
    class AutoMapperTests
    {
        [Test]
        public void ShouldMapCreateCustomerViewModeToCustomer()
        {
            //arrange
            AutoMapperConfig.RegisterMaps();

            var cvm = new CreateCustomerViewModel()
            {
                FirstName = "Justin",
                LastName = "Patterson",
                CompanyName = "CRM",
                UseEmailForGravatar = true,
                EmailAddress = "justin.patterson@gmail.com",
                Street = "123 street lane",
                City = "Fort Worth",
                State = "TX",
                PostalCode = "76111",
                PhoneNumber = "3333333333"
                
            };

            //act
            Customer customer = Mapper.Map<Customer>(cvm);

            //assert
            Assert.That(customer.FirstName, Is.EqualTo(cvm.FirstName));
            Assert.That(customer.LastName, Is.EqualTo(cvm.LastName));
            Assert.That(customer.CompanyName, Is.EqualTo(cvm.CompanyName));
            Assert.That(customer.EmailAddress, Is.EqualTo(cvm.EmailAddress));
            Assert.That(customer.AvatarUrl, Is.EqualTo(GravatarUtil.GetGravatarImgUrl(cvm.EmailAddress)));
            Assert.That(customer.Address.Street, Is.EqualTo(cvm.Street));
            Assert.That(customer.Address.City, Is.EqualTo(cvm.City));
            Assert.That(customer.Address.State, Is.EqualTo(cvm.State));
            Assert.That(customer.Address.PostalCode, Is.EqualTo(cvm.PostalCode));
            Assert.That(customer.PhoneNumber, Is.EqualTo(cvm.PhoneNumber));
        }

        [Test]
        public void ShouldMapEditCustomerViewModeToCustomer()
        {
            //arrange
            AutoMapperConfig.RegisterMaps();

            var cvm = new EditCustomerViewModel()
            {
                Id = 1,
                AddressId = 0,
                FirstName = "Justin",
                LastName = "Patterson",
                CompanyName = "CRM",
                UseEmailForGravatar = true,
                EmailAddress = "justin.patterson@gmail.com",
                Street = "123 street lane",
                City = "Fort Worth",
                State = "TX",
                PostalCode = "76111",
                PhoneNumber = "3333333333"

            };

            //act
            Customer customer = Mapper.Map<Customer>(cvm);

            
            //assert
            Assert.That(customer.Id, Is.EqualTo(cvm.Id));
            Assert.That(customer.Address.Id, Is.EqualTo(cvm.AddressId));
            Assert.That(customer.FirstName, Is.EqualTo(cvm.FirstName));
            Assert.That(customer.LastName, Is.EqualTo(cvm.LastName));
            Assert.That(customer.CompanyName, Is.EqualTo(cvm.CompanyName));
            Assert.That(customer.EmailAddress, Is.EqualTo(cvm.EmailAddress));
            Assert.That(customer.AvatarUrl, Is.EqualTo(GravatarUtil.GetGravatarImgUrl(cvm.EmailAddress)));
            Assert.That(customer.Address.Street, Is.EqualTo(cvm.Street));
            Assert.That(customer.Address.City, Is.EqualTo(cvm.City));
            Assert.That(customer.Address.State, Is.EqualTo(cvm.State));
            Assert.That(customer.Address.PostalCode, Is.EqualTo(cvm.PostalCode));
            Assert.That(customer.PhoneNumber, Is.EqualTo(cvm.PhoneNumber));
        }
        [Test]
        public void ShouldMapCustomerToEditCustomerViewMode()
        {
            //arrange
            AutoMapperConfig.RegisterMaps();

            var customer = new Customer()
            {
                Id = 1,
                FirstName = "Justin",
                LastName = "Patterson",
                CompanyName = "CRM",
                EmailAddress = "justin.patterson@gmail.com",
                PhoneNumber = "3333333333",
                Address = new Address()
                {
                    Street = "123 street lane",
                    City = "Fort Worth",
                    State = "TX",
                    PostalCode = "76111",
                }
            };

            customer.AvatarUrl = GravatarUtil.GetGravatarImgUrl(customer.EmailAddress);

            //act
            EditCustomerViewModel ecvm = Mapper.Map<EditCustomerViewModel>(customer);


            //assert
            Assert.That(ecvm.Id, Is.EqualTo(customer.Id));
            Assert.That(ecvm.AddressId, Is.EqualTo(customer.Address.Id));
            Assert.That(ecvm.FirstName, Is.EqualTo(customer.FirstName));
            Assert.That(ecvm.LastName, Is.EqualTo(customer.LastName));
            Assert.That(ecvm.CompanyName, Is.EqualTo(customer.CompanyName));
            Assert.That(ecvm.EmailAddress, Is.EqualTo(customer.EmailAddress));
            Assert.That(ecvm.UseEmailForGravatar, Is.EqualTo(true));
            Assert.That(ecvm.Street, Is.EqualTo(customer.Address.Street));
            Assert.That(ecvm.City, Is.EqualTo(customer.Address.City));
            Assert.That(ecvm.State, Is.EqualTo(customer.Address.State));
            Assert.That(ecvm.PostalCode, Is.EqualTo(customer.Address.PostalCode));
            Assert.That(ecvm.PhoneNumber, Is.EqualTo(customer.PhoneNumber));
        }

        [Test]
        public void ShouldMapCustomerToDetailsCustomerViewMode()
        {
            //arrange
            AutoMapperConfig.RegisterMaps();
            string expectedAddress = String.Join(System.Environment.NewLine, new string[] { 
                        "123 street lane",
                        "Fort Worth",
                        "TX",
                        "76111"
                    });

            var customer = new Customer()
            {
                Id = 1,
                FirstName = "Justin",
                LastName = "Patterson",
                CompanyName = "CRM",
                EmailAddress = "justin.patterson@gmail.com",
                PhoneNumber = "3333333333",
                Address = new Address()
                {
                    Street = "123 street lane",
                    City = "Fort Worth",
                    State = "TX",
                    PostalCode = "76111",
                },
                Notes = new List<Note>()
            };

            customer.Notes.Add(new Note()
            {
                Body = "Test Note",
                Id = 0
            });


            customer.AvatarUrl = GravatarUtil.GetGravatarImgUrl(customer.EmailAddress);

            //act
            DetailsCustomerViewModel dcvm = Mapper.Map<DetailsCustomerViewModel>(customer);


            //assert
            Assert.That(dcvm.Id, Is.EqualTo(customer.Id));
            Assert.That(dcvm.Notes.Count, Is.EqualTo(customer.Notes.Count));
            Assert.That(dcvm.FirstName, Is.EqualTo(customer.FirstName));
            Assert.That(dcvm.LastName, Is.EqualTo(customer.LastName));
            Assert.That(dcvm.CompanyName, Is.EqualTo(customer.CompanyName));
            Assert.That(dcvm.EmailAddress, Is.EqualTo(customer.EmailAddress));
            Assert.That(dcvm.PhoneNumber, Is.EqualTo(customer.PhoneNumber));
            Assert.That(dcvm.AvatarUrl, Is.EqualTo(customer.AvatarUrl));
            Assert.That(dcvm.Address, Is.EqualTo(expectedAddress));
        }

        [Test]
        public void ShouldMapNoteToNoteViewModel()
        {
            //arrange
            AutoMapperConfig.RegisterMaps();
            Note note = new Note()
            {
                Body = "Note",
                Id = 0,
                User = new ApplicationUser()
                {
                    UserName = "justin"
                },
                Customer = new Customer()
                {
                    FirstName = "Justin",
                    LastName = "Patterson"
                }
            };

            //act
            NoteViewModel nvm = Mapper.Map<NoteViewModel>(note);

            //assert
            Assert.That(nvm.UserName, Is.EqualTo(note.User.UserName));
            Assert.That(nvm.Id, Is.EqualTo(note.Id));
            Assert.That(nvm.Body, Is.EqualTo(note.Body));
            Assert.That(nvm.CustomerName, Is.EqualTo("Justin Patterson"));
            Assert.That(String.IsNullOrWhiteSpace(nvm.LastPage), Is.True);
        }

        [Test]
        public void ShouldMapNoteViewModelToNote()
        {
            //arrange
            AutoMapperConfig.RegisterMaps();
            NoteViewModel nvm = new NoteViewModel()
            {
                Body = "Note",
                Id = 0,
                UserName = "justin",
                LastPage = "http://google.com"
            };

            //act
            Note note = Mapper.Map<Note>(nvm);

            //assert
            Assert.That(note.User, Is.Null);
            Assert.That(note.Customer, Is.Null);
            Assert.That(note.Id, Is.EqualTo(nvm.Id));
            Assert.That(note.Body, Is.EqualTo(nvm.Body));
        }


    }
}
