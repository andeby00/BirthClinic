using System;
using System.Collections.Generic;
using System.Text;
using BirthClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace BirthClinic.DataAccess
{
    public class Context : DbContext
    {

        public Context() 
        { }

        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

     

        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseSqlServer(
                @"Data Source = (localdb)\dab_server; Initial Catalog = BirthClinicDb; Integrated Security = True;");

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Birth>()
                .HasMany(b => b.Child)
                .
        }
    }
}
