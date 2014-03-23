using Highway.Data;
using ogsysCRM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;

namespace ogsysCRM.Mappings
{
    public class NoteMap : EntityTypeConfiguration<Note>
    {
        /// <summary>
        /// Initializes a new instance of the NoteMap class.
        /// </summary>
        public NoteMap()
        {
            ToTable("Notes");
        }
    }
}
