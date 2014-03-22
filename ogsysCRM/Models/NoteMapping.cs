using Highway.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ogsysCRM.Models
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
