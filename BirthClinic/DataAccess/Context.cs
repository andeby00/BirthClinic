using System;
using System.Collections.Generic;
using System.Text;
using BirthClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace BirthClinic.DataAccess
{
    public class Context : DbContext
    {
        public DbSet<Birth> birth { get; set; }
        public DbSet<BirthRoom> birthRoom { get; set; }
        public DbSet<Child> child { get; set; }
        public DbSet<Clinician> clinician { get; set; }
        public DbSet<Doctor> doctor { get; set; }
        public DbSet<MaternityRoom> maternityRoom { get; set; }
        public DbSet<Midwife> midwife { get; set; }
        public DbSet<Nurse> nurse { get; set; }
        public DbSet<Parent> parent { get; set; }
        public DbSet<RestRoom> restRoom { get; set; }
        public DbSet<Secretary> secretary { get; set; }
        public DbSet<Shift> shift { get; set; }
        public DbSet<SocialHealthAss> socialHealthAss { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder ob)
        {
            ob.UseSqlServer(
                @"Data Source = (localdb)\dab_server; Initial Catalog = BirthClinicDb; Integrated Security = True;");

        }

    }
}
