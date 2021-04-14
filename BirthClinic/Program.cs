using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BirthClinic.DataAccess;
using BirthClinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace BirthClinic
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Creating data and seeding it to the db . . .\n\n");
            Context clinicContext = new Context();
            SeedDB seedDb = new SeedDB();

            List<Clinician> clinicians1 = new List<Clinician>();
            clinicians1 = seedDb.GenerateClinicians();
            clinicContext.AddRange(clinicians1);

            List<Clinician> clinicians2 = new List<Clinician>();
            clinicians2 = seedDb.GenerateClinicians();
            clinicContext.AddRange(clinicians2);

            List<Clinician> clinicians3 = new List<Clinician>();
            clinicians3 = seedDb.GenerateClinicians();
            clinicContext.AddRange(clinicians3);

            List<Clinician> clinicians4 = new List<Clinician>();
            clinicians4 = seedDb.GenerateClinicians();
            clinicContext.AddRange(clinicians4);

            List<Clinician> clinicians5 = new List<Clinician>();
            clinicians5 = seedDb.GenerateClinicians();
            clinicContext.AddRange(clinicians5);

            List<Clinician> clinicians6 = new List<Clinician>();
            clinicians6 = seedDb.GenerateClinicians();
            clinicContext.AddRange(clinicians6);

            List<Shift> shiftList = new List<Shift>();
            shiftList.Add(seedDb.GenerateShift(clinicians1, DateTime.Today));
            shiftList.Add(seedDb.GenerateShift(clinicians2, DateTime.Today.AddDays(1)));
            shiftList.Add(seedDb.GenerateShift(clinicians3, DateTime.Today.AddDays(2)));
            shiftList.Add(seedDb.GenerateShift(clinicians4, DateTime.Today.AddDays(3)));
            shiftList.Add(seedDb.GenerateShift(clinicians5, DateTime.Today.AddDays(4)));
            shiftList.Add(seedDb.GenerateShift(clinicians6, DateTime.Today.AddDays(6)));
            clinicContext.AddRange(shiftList);

            List<Parent> parents = new List<Parent>();
            for (int i = 0; i < 10; i++)
            {
                parents.Add(seedDb.GenerateParent());
            }
            clinicContext.AddRange(parents);

            List<BirthRoom> birthRooms = seedDb.GenerateBirthRooms();
            List<MaternityRoom> maternityRooms = seedDb.GenerateMaternityRooms();
            List<RestRoom> restRooms = seedDb.GenerateRestRooms();
            clinicContext.AddRange(birthRooms);
            clinicContext.AddRange(maternityRooms);
            clinicContext.AddRange(restRooms);

            List<Birth> births = new List<Birth>();

            births.Add(seedDb.ScheduleBirth(new List<Clinician>() { clinicians1[0], clinicians1[1], clinicians1[2], clinicians1[3], clinicians1[4], clinicians1[5], clinicians1[6], clinicians1[7], clinicians1[8], clinicians1[9] }, new List<Parent>() { parents[0], parents[1] }, birthRooms[0], maternityRooms[0], restRooms[0], DateTime.Now));
            births.Add(seedDb.ScheduleBirth(new List<Clinician>() { clinicians4[0], clinicians4[1], clinicians4[2], clinicians4[3], clinicians4[4], clinicians4[5], clinicians4[6], clinicians4[7], clinicians4[8], clinicians4[9] }, new List<Parent>() { parents[6], parents[7] }, birthRooms[0], maternityRooms[0], restRooms[0], DateTime.Today.AddDays(3)));
            births.Add(seedDb.ScheduleBirth(new List<Clinician>() { clinicians3[0], clinicians3[1], clinicians3[2], clinicians3[3], clinicians3[4], clinicians3[5], clinicians3[6], clinicians3[7], clinicians3[8], clinicians3[9] }, new List<Parent>() { parents[2], parents[3] }, birthRooms[1], maternityRooms[1], restRooms[1], DateTime.Today.AddDays(2)));
            births.Add(seedDb.ScheduleBirth(new List<Clinician>() { clinicians5[0], clinicians5[1], clinicians5[2], clinicians5[3], clinicians5[4], clinicians5[5], clinicians5[6], clinicians5[7], clinicians5[8], clinicians5[9] }, new List<Parent>() { parents[4], parents[5] }, birthRooms[2], maternityRooms[2], restRooms[2], DateTime.Today.AddDays(9)));
            births.Add(seedDb.ScheduleBirth(new List<Clinician>() { clinicians2[0], clinicians2[1], clinicians2[2], clinicians2[3], clinicians2[4], clinicians2[5], clinicians2[6], clinicians2[7], clinicians2[8], clinicians2[9] }, new List<Parent>() { parents[8], parents[9] }, birthRooms[3], maternityRooms[3], restRooms[3], DateTime.Today));
            clinicContext.AddRange(births);

            seedDb.StartBirth(births[0]);
            List<Child> childrenList1 = seedDb.EndBirth(births[4]);
            clinicContext.AddRange(childrenList1);
            clinicContext.SaveChanges();


            //View 1: - view 1 is made with the use of "Linq" library
            var view1 = from birth in clinicContext.birth
                        where birth.ScheduledTime < DateTime.Today.AddDays(4) && birth.ScheduledTime > DateTime.Today.AddDays(1)
                        select birth;

            Console.WriteLine("View 1 - Planned births for next 3 days");
            Console.WriteLine(".......................................................");

            foreach (Birth b in view1)
            {
                Console.WriteLine(@"Birth {0} is scheduled for {1}", b.Id, b.ScheduledTime);
            }

            Console.WriteLine("_____________________________________");
            Console.WriteLine();
            Console.WriteLine();


            //View 2: - View 2-5 is made with the Eager method
            List<Clinician> clinicianList2 = clinicContext.clinician
                .Include(c => c.Birth)
                .ToList();

            List<BirthRoom> birthRoomList2 = clinicContext.birthRoom
                .Include(b => b.Births)
                .ToList();

            List<MaternityRoom> maternityRoomList2 = clinicContext.maternityRoom
                .Include(m => m.Births)
                .ToList();

            List<RestRoom> restRoomList2 = clinicContext.restRoom
                .Include(r => r.Births)
                .ToList();

            Console.WriteLine("View 2 - Available rooms and clinicians for the next 5 days:");
            Console.WriteLine(".......................................................");

            Console.WriteLine("Available clinicians:");
            Console.WriteLine();

            int counter = 0;
            foreach (var c in clinicianList2)
            {
                bool available = false;

                if (c.Birth == null)
                {
                    available = true;
                    counter++;
                }
                else if (c.Birth.ScheduledTime < DateTime.Today || c.Birth.ScheduledTime > DateTime.Today.AddDays(6))
                {
                    available = true;
                    counter++;
                }

                if (available)
                {
                    Console.WriteLine(c.FirstName + " " + c.LastName);
                }
            }
           
            Console.WriteLine("For double checking the result: There should be 314 available clinicians.");
            Console.WriteLine("There are: " + counter + " available");

            Console.WriteLine();
            Console.WriteLine("Available rooms:");
            Console.WriteLine();

            Console.WriteLine("Birth rooms:");
            foreach (var br in birthRoomList2)
            {
                bool Available = false;

                foreach (var birth in br.Births)
                {
                    if (birth.ScheduledTime > DateTime.Today.AddDays(6))
                    {
                        Available = true;
                    }
                }
                if (br.Births.Count == 0)
                {
                    Available = true;
                }

                if (Available)
                {
                    Console.WriteLine("Room number: " + br.RoomNumber);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Maternity rooms:");
            Console.WriteLine();

            foreach (var mr in maternityRoomList2)
            {
                bool Available = false;

                foreach (var birth in mr.Births)
                {
                    if (birth.ScheduledTime > DateTime.Today.AddDays(6))
                    {
                        Available = true;
                    }
                }
                if (mr.Births.Count == 0)
                {
                    Available = true;
                }

                if (Available)
                {
                    Console.WriteLine("Room number: " + mr.RoomNumber);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Rest rooms:");
            Console.WriteLine();

            foreach (var rr in restRoomList2)
            {
                bool Available = false;

                foreach (var birth in rr.Births)
                {
                    if (birth.ScheduledTime > DateTime.Today.AddDays(6))
                    {
                        Available = true;
                    }
                }
                if (rr.Births.Count == 0)
                {
                    Available = true;
                }

                if (Available)
                {
                    Console.WriteLine("Room number: " + rr.RoomNumber);
                }
            }

            Console.WriteLine("_____________________________________");
            Console.WriteLine();
            Console.WriteLine();


            ////View 3:
            List<Birth> birthList3 = clinicContext.birth
                    .Include(b => b.Parents)
                    .Include(b => b.Clinicians)
                    .Include(b => b.BirthRoom)
                    .ToList();


            Console.WriteLine("View 3 - Current births");
            Console.WriteLine(".......................................................");

            Console.WriteLine("Current births:");
            Console.WriteLine();
            foreach (var b in birthList3)
            {
                if (b.Ended == 0)
                {
                    Console.WriteLine("Birth id: " + b.Id);
                    Console.WriteLine("Birth room: " + b.BirthRoom.RoomNumber);
                    Console.WriteLine("Clinicians:");
                    foreach (var c in b.Clinicians)
                    {
                        Console.WriteLine(c.FirstName + " " + c.LastName);
                    }
                    Console.WriteLine("Parents:");
                    foreach (var p in b.Parents)
                    {
                        Console.WriteLine(p.FirstName + " " + p.LastName);
                    }
                }
            }

            Console.WriteLine("_____________________________________");
            Console.WriteLine();
            Console.WriteLine();


            //View 4:
            List<Birth> birthList4 = clinicContext.birth
                        .Include(b => b.Children)
                        .Include(b => b.Parents)
                        .Include(b => b.MaternityRoom)
                        .Include(b => b.RestRoom)
                        .ToList();

            Console.WriteLine("View 4 - Maternity rooms and 4h rest rooms in use with the parents and child/children");
            Console.WriteLine(".......................................................");

            Console.WriteLine("Rooms in use:");
            Console.WriteLine();

            foreach (var b in birthList4)
            {
                if (b.ScheduledTime == DateTime.Today)
                {
                    Console.WriteLine("Maternity room: " + b.MaternityRoom.RoomNumber);
                    Console.WriteLine("Rest room: " + b.RestRoom.RoomNumber);
                    Console.WriteLine("Parents:");
                    foreach (var p in b.Parents)
                    {
                        Console.WriteLine(p.FirstName + " " + p.LastName);
                    }
                    Console.WriteLine("Child/Children:");
                    foreach (var c in b.Children)
                    {
                        Console.WriteLine("Child id: " + c.ChildId);
                        Console.WriteLine("Child gender: " + c.Gender);
                        if (c.DeathAtBirth)
                        {
                            Console.WriteLine("The baby is dead");
                        }
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("_____________________________________");
            Console.WriteLine();
            Console.WriteLine();


            //View 5:
            List<Birth> birthList5 = clinicContext.birth
                        .Include(b => b.Clinicians)
                        .Include(b => b.BirthRoom)
                        .Include(b => b.MaternityRoom)
                        .Include(b => b.RestRoom)
                        .ToList();

            Console.WriteLine("View 5 - Planned births and its reserved rooms");
            Console.WriteLine(".......................................................");

            Console.WriteLine("Planned births: ");
            Console.WriteLine();

            foreach (var b in birthList5)
            {
                Console.WriteLine("Birth id: " + b.Id);
                Console.WriteLine("Scheduled time: " + b.ScheduledTime);
                Console.WriteLine("Birth room booked: " + b.BirthRoom.RoomNumber);
                Console.WriteLine("Maternity room booked: " + b.MaternityRoom.RoomNumber);
                Console.WriteLine("Rest room booked: " + b.RestRoom.RoomNumber);
                Console.WriteLine("Clinicians booked:");
                foreach (var c in b.Clinicians)
                {
                    Console.WriteLine(c.FirstName + " " + c.LastName);
                }
                
                Console.WriteLine();
            }

            Console.WriteLine("_____________________________________");
        }
    }
}
