using BirthClinic.DataAccess;
using BirthClinic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BirthClinic
{
    class Views
    {


        public void viewPlannedBirths(Context clinicContext)
        {
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
        }

        public void viewAvailableCliniciansAndRooms(Context clinicContext)
        {
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

        }

        public void viewOngoingBirths(Context clinicContext)
        {
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
        }

        public void viewOccupiedMaternityAndRest(Context clinicContext)
        {
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
                
            }

            Console.WriteLine("_____________________________________");
            Console.WriteLine();
            Console.WriteLine();
        }

        public void viewSpecifiedBirth(Context clinicContext)
        {
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
