using System;
using System.Linq;
using Highway.Data;
using System.Collections.Generic;
using ogsysCRM.Models;
using System.Data.Entity;
using AutoMapper;

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
            return _repository.Find(new CustomersByLastName(p));
        }

        public Customer GetCustomerById(int id)
        {
            return _repository.Find(new CustomerById(id));
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _repository.Find(new AllCustomers());
        }

        public void UpdateCustomer(Customer customer)
        {
            _repository.Context.Update(customer);
            _repository.Context.Update(customer.Address);
            _repository.Context.Commit();
        }
        public void AddNote(Note note)
        {
            _repository.Execute(new AddNote(note));
        }

        public void DeleteNoteById(int noteId)
        {
            _repository.Execute(new DeleteNoteById(noteId));
        }

        public Note NoteById(int noteId)
        {
            return _repository.Find(new NoteById(noteId));
        }

        public void UpdateNote(Note note)
        {
            _repository.Execute(new UpdateNote(note));
        }

        public ApplicationUser GetUserByUserName(string userName)
        {
            return _repository.Find(new UserByUserName(userName));
        }
    }

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

    public class UserByUserName : Scalar<ApplicationUser>
    {
        
        public UserByUserName(string userName)
        {
            ContextQuery = c => c.AsQueryable<ApplicationUser>()
                .Include(x => x.Notes)
                .SingleOrDefault(x => x.UserName == userName);
        }
    }

    public class AddNote : Command
    {
        
        public AddNote(Note note)
        {
            ContextQuery = c =>
            {
                c.Add<Note>(note);
                c.Commit();
            };
        }
    }

    public class UpdateNote : Command
    {
        
        public UpdateNote(Note note)
        {
            ContextQuery = c =>
            {
                c.Update(note);
                c.Commit();
            };
        }
    }

    public class NoteById : Scalar<Note>
    {
        
        public NoteById(int id)
        {
            ContextQuery = c => c.AsQueryable<Note>()
                .Include(x => x.Customer.Address)
                .Include(x => x.User)
                .SingleOrDefault(x => x.Id == id);

        }
    }

    public class DeleteNoteById : Command
    {
        
        public DeleteNoteById(int noteId)
        {
            ContextQuery = c =>
            {
                var note = c.AsQueryable<Note>().SingleOrDefault(x => x.Id == noteId);
                c.Remove<Note>(note);
                c.Commit();
            };

        }
    }

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
