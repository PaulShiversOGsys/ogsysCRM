using Highway.Data;
using ogsysCRM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ogsysCRM.Mappings
{
    public class NoteMapping : IMappingConfiguration
    {
        public void ConfigureModelBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Note>()
                .ToTable("Notes");
        }
    }
}
