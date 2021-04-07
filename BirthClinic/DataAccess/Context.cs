using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BirthClinic.DataAccess
{
    class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseSqlServer(
                @"Data Source = (localdb)\dab_server; Initial Catalog = BookStore; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
        }
    }
}
