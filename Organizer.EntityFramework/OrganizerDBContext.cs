using Microsoft.EntityFrameworkCore;
using OrganizerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace Organizer.EntityFramework
{
    public class OrganizerDBContext:DbContext
    {
        public OrganizerDBContext(DbContextOptions options) : base(options) { }
      
        public DbSet<ListModel> ListModels { get; set; }

        public DbSet<SectionModel> SectionModels { get; set; }

        public DbSet<EventModel> EventModels { get; set; }

        public DbSet<CheckBoxModel> CheckBoxModels { get; set; }

        public DbSet<NotesModel> NotesModels { get; set; }


    }
}
