using System;
using System.Linq;
using Highway.Data;
using System.Collections.Generic;
using ogsysCRM.Models;
using ogsysCRM.Queries.CustomerQueries;
using ogsysCRM.Queries.NoteQueries;
using ogsysCRM.Queries.UserQueries;

namespace ogsysCRM.Services
{
    public class CRMService
    {
        private readonly IRepository _repository;

        public CRMService(IRepository repository)
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
}