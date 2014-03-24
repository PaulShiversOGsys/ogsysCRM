using System;
using System.Linq;
using Highway.Data;
using System.Collections.Generic;
using ogsysCRM.Models;
using System.Data.Entity;
using AutoMapper;

namespace ogsysCRM.Queries.NoteQueries
{
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
}
