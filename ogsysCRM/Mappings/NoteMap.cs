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
            HasRequired(x => x.Customer)
                .WithMany(x => x.Notes)
                .WillCascadeOnDelete(true);
            //HasRequired(x => x.User)
            //    .WithMany(x => x.Notes)
            //    .WillCascadeOnDelete(true);
        }
    }
}
