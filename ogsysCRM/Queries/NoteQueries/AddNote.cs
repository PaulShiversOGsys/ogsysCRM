using System;
using System.Linq;
using Highway.Data;
using System.Collections.Generic;
using ogsysCRM.Models;

namespace ogsysCRM.Queries.NoteQueries
{
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
}
