using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Organizer.EntityFramework
{
    public class OrganizerDbContextFactory : IDesignTimeDbContextFactory<OrganizerDBContext>
    {
        public OrganizerDBContext CreateDbContext(string[] args =null)
        {
            var options = new DbContextOptionsBuilder<OrganizerDBContext>();
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=OrganizerDB;Trusted_Connection=True;");

            return new OrganizerDBContext(options.Options);
        }
    }
}
