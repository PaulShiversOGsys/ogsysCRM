using System;
using System.Linq;
using Highway.Data;
using System.Collections.Generic;
using ogsysCRM.Models;

namespace ogsysCRM.Queries.NoteQueries
{
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
}
