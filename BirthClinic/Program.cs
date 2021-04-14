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
            Context clinicContext = new Context();
            SeedDB seedDb = new SeedDB();

            //List<Clinician> clinicianList1 = new List<Clinician>();
            //clinicianList1 = seedDb.GenerateClinicians();
            //clinicContext.AddRange(clinicianList1);

            //List<Clinician> clinicianList2 = new List<Clinician>();
            //clinicianList2 = seedDb.GenerateClinicians();
            //clinicContext.AddRange(clinicianList2);

            //List<Clinician> clinicianList3 = new List<Clinician>();
            //clinicianList3 = seedDb.GenerateClinicians();
            //clinicContext.AddRange(clinicianList3);

            //List<Clinician> clinicianList4 = new List<Clinician>();
            //clinicianList4 = seedDb.GenerateClinicians();
            //clinicContext.AddRange(clinicianList4);

            //List<Clinician> clinicianList5 = new List<Clinician>();
            //clinicianList5 = seedDb.GenerateClinicians();
            //clinicContext.AddRange(clinicianList5);

            //List<Clinician> clinicianList6 = new List<Clinician>();
            //clinicianList6 = seedDb.GenerateClinicians();
            //clinicContext.AddRange(clinicianList6);

            //List<Shift> shiftList = new List<Shift>();
            //shiftList.Add(seedDb.GenerateShift(clinicianList1, DateTime.Today));
            //shiftList.Add(seedDb.GenerateShift(clinicianList2, DateTime.Today.AddDays(1)));
            //shiftList.Add(seedDb.GenerateShift(clinicianList3, DateTime.Today.AddDays(2)));
            //shiftList.Add(seedDb.GenerateShift(clinicianList4, DateTime.Today.AddDays(3)));
            //shiftList.Add(seedDb.GenerateShift(clinicianList5, DateTime.Today.AddDays(4)));
            //shiftList.Add(seedDb.GenerateShift(clinicianList6, DateTime.Today.AddDays(6)));
            //clinicContext.AddRange(shiftList);

            //List<Parent> parents = new List<Parent>();          ////code below this hasnt been run 
            //for (int i = 0; i < 10; i++)
            //{
            //    parents.Add(seedDb.GenerateParent());
            //}
            //clinicContext.AddRange(parents);

            //List<BirthRoom> birthRooms = seedDb.GenerateBirthRooms();
            //List<MaternityRoom> maternityRooms = seedDb.GenerateMaternityRooms();
            //List<RestRoom> restRooms = seedDb.GenerateRestRooms();
            //clinicContext.AddRange(birthRooms);
            //clinicContext.AddRange(maternityRooms);
            //clinicContext.AddRange(restRooms);

            //List<Birth> births = new List<Birth>();

            //births.Add(seedDb.ScheduleBirth(clinicianList1, new List<Parent>() { parents[0], parents[1] }, birthRooms[0], maternityRooms[0], restRooms[0], DateTime.Now));
            //births.Add(seedDb.ScheduleBirth(clinicianList4, new List<Parent>() { parents[6], parents[7] }, birthRooms[0], maternityRooms[0], restRooms[0], DateTime.Today.AddDays(3)));
            //births.Add(seedDb.ScheduleBirth(clinicianList3, new List<Parent>() { parents[2], parents[3] }, birthRooms[1], maternityRooms[1], restRooms[1], DateTime.Today.AddDays(2)));
            //births.Add(seedDb.ScheduleBirth(clinicianList6, new List<Parent>() { parents[4], parents[5] }, birthRooms[2], maternityRooms[2], restRooms[2], DateTime.Today.AddDays(6)));
            //births.Add(seedDb.ScheduleBirth(clinicianList1, new List<Parent>() { parents[8], parents[9] }, birthRooms[3], maternityRooms[3], restRooms[3], DateTime.Today));
            //clinicContext.AddRange(births);
            //seedDb.StartBirth(births[0]);

            //List<Child> childrenList1 = seedDb.EndBirth(births[4]);
            //clinicContext.AddRange(childrenList1);
            //clinicContext.SaveChanges();

            var view1 = from birth in clinicContext.birth
                        where birth.ScheduledTime < DateTime.Today.AddDays(4) && birth.ScheduledTime > DateTime.Today.AddDays(1)
                        select birth;
            Console.WriteLine("View 1 - Planned births for next 3 days:");
            Console.WriteLine("_____________________________________");
            foreach (Birth b in view1)
            {
                Console.WriteLine(@"Birth {0} is scheduled for {1}", b.Id, b.ScheduledTime);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            var Bview2 = from b in clinicContext.birth
                               where b.Id == null
                               select b;
            var Cview2 = from c in clinicContext.clinician 
                               join b in Bview2 on c.BirthId equals b.Id 
                               where b.ScheduledTime > DateTime.Today.AddDays(6) 
                               select c;
            var BRview2 = from br in clinicContext.birthRoom
                               join b in Bview2 on br.BirthRoomId equals b.BirthRoomID
                               where b.ScheduledTime > DateTime.Today.AddDays(6)
                               select br;
            var RRview2 = from rr in clinicContext.restRoom
                               join b in Bview2 on rr.Id equals b.RestRoomID
                               where b.ScheduledTime > DateTime.Today.AddDays(6) 
                               select rr;
            var MRview2 = from mr in clinicContext.maternityRoom
                               join b in Bview2 on mr.Id equals b.MaternityRoomID
                               where b.ScheduledTime > DateTime.Today.AddDays(6) 
                               select mr;
            var view2_c = from c in clinicContext.clinician 
                               where c.BirthId == null 
                               select c;

            var view2_br = from br in clinicContext.birthRoom 
                               where br.Births == null 
                               select br;

            var view2_mr = from mr in clinicContext.maternityRoom 
                               where mr.Births == null 
                               select mr;

            var view2_rr = from rr in clinicContext.restRoom 
                               where rr.Births == null 
                               select rr;

            //var view2 = clinicContext.birth
            //        .Where(b =>  b.ScheduledTime > DateTime.Now && b.ScheduledTime < DateTime.Today.AddDays(6) )
            //        //.Include(c => c.Clinicians)
            //        .Include(br => br.BirthRoom)
            //        .Include(rr => rr.RestRoom)
            //        .Include(mr => mr.MaternityRoom)
            //        .ToList();
            Console.WriteLine("View 2 - Available rooms and clinicians for the next 5 days:");
            Console.WriteLine("_____________________________________");

            foreach (var c in view2_c)
            {
                Console.WriteLine("Available clinician: " + c.FirstName + " " + c.LastName);
            }
            foreach (var c in Cview2)
            {
                Console.WriteLine("Available clinician: " + c.FirstName + " " + c.LastName);
            }

            foreach (var br in view2_br)
            {
                Console.WriteLine("Available birthroom: " + br.RoomNumber);
            }
            foreach (var br in BRview2)
            {
                Console.WriteLine("Available birthroom: " + br.RoomNumber);
            }

            foreach (var mr in view2_mr)
            {
                Console.WriteLine("Available m-room: " + mr.RoomNumber);
            }
            foreach (var mr in MRview2)
            {
                Console.WriteLine("Available m-room: " + mr.RoomNumber);
            }

            foreach (var rr in view2_rr)
            {
                Console.WriteLine("Available rest room: " + rr.RoomNumber);
            }
            foreach (var rr in RRview2)
            {
                Console.WriteLine("Available rest room: " + rr.RoomNumber);
            }
            
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            
        }
    }
}
