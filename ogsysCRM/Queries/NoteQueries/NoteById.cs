using System;
using System.Linq;
using Highway.Data;
using System.Collections.Generic;
using ogsysCRM.Models;
using System.Data.Entity;
using AutoMapper;

namespace ogsysCRM.Queries.NoteQueries
{
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
}
