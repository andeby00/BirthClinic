using System;
using System.Collections.Generic;
using System.Text;
using BirthClinic.Models;
using Microsoft.EntityFrameworkCore;

namespace BirthClinic.DataAccess
{
    public class Context : DbContext
    {

        public DbSet<Birth> births { get; set; }
        public DbSet<BirthClinic> birthClinics { get; set; }
        public DbSet<BirthRoom> birthRooms { get; set; }
        public DbSet<Child> children { get; set; }
        public DbSet<Clinician> clinicians { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<MaternityRoom> maternityRooms { get; set; }
        public DbSet<Midwife> midwives { get; set; }
        public DbSet<Nurse> nurses { get; set; }
        public DbSet<Parent> parents { get; set; }
        public DbSet<RestRoom> restRooms { get; set; }
        public DbSet<Secretary> secretaries { get; set; }
        public DbSet<SocialHealthAss> socialHealthAsses { get; set; }

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
