using System;
using System.Collections.Generic;
using System.IO;
using BirthClinic.DataAccess;
using BirthClinic.Models;

namespace BirthClinic
{
    class Program
    {
        static void Main(string[] args)
        {
            Context clinicContext = new Context();
            SeedDB seedDb = new SeedDB();

            List<Clinician> clinicianList1 = new List<Clinician>();
            clinicianList1 = seedDb.GenerateClinicians();
            clinicContext.AddRange(clinicianList1);

            List<Clinician> clinicianList2 = new List<Clinician>();
            clinicianList2 = seedDb.GenerateClinicians();
            clinicContext.AddRange(clinicianList2);

            List<Clinician> clinicianList3 = new List<Clinician>();
            clinicianList3 = seedDb.GenerateClinicians();
            clinicContext.AddRange(clinicianList3);

            List<Clinician> clinicianList4 = new List<Clinician>();
            clinicianList4 = seedDb.GenerateClinicians();
            clinicContext.AddRange(clinicianList4);

            List<Clinician> clinicianList5 = new List<Clinician>();
            clinicianList5 = seedDb.GenerateClinicians();
            clinicContext.AddRange(clinicianList5);

            List<Clinician> clinicianList6 = new List<Clinician>();
            clinicianList6 = seedDb.GenerateClinicians();
            clinicContext.AddRange(clinicianList6);

            List<Shift> shiftList = new List<Shift>();
            shiftList.Add(seedDb.GenerateShift(clinicianList1, DateTime.Today));
            shiftList.Add(seedDb.GenerateShift(clinicianList2, DateTime.Today.AddDays(1)));
            shiftList.Add(seedDb.GenerateShift(clinicianList3, DateTime.Today.AddDays(2)));
            shiftList.Add(seedDb.GenerateShift(clinicianList4, DateTime.Today.AddDays(3)));
            shiftList.Add(seedDb.GenerateShift(clinicianList5, DateTime.Today.AddDays(4)));
            shiftList.Add(seedDb.GenerateShift(clinicianList6, DateTime.Today.AddDays(6)));
            clinicContext.AddRange(shiftList);

            List<Parent> parents = new List<Parent>();          ////code below this hasnt been run 
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

            births.Add(seedDb.ScheduleBirth(clinicianList1, new List<Parent>() { parents[0], parents[1] }, birthRooms[0], maternityRooms[0], restRooms[0], DateTime.Now));
            births.Add(seedDb.ScheduleBirth(clinicianList4, new List<Parent>() { parents[6], parents[7] }, birthRooms[0], maternityRooms[0], restRooms[0], DateTime.Today.AddDays(3)));
            births.Add(seedDb.ScheduleBirth(clinicianList3, new List<Parent>() { parents[2], parents[3] }, birthRooms[1], maternityRooms[1], restRooms[1], DateTime.Today.AddDays(2)));
            births.Add(seedDb.ScheduleBirth(clinicianList6, new List<Parent>() { parents[4], parents[5] }, birthRooms[2], maternityRooms[2], restRooms[2], DateTime.Today.AddDays(6)));
            births.Add(seedDb.ScheduleBirth(clinicianList1, new List<Parent>() { parents[8], parents[9] }, birthRooms[3], maternityRooms[3], restRooms[3], DateTime.Today));

            seedDb.StartBirth(births[0]);

            List<Child> childrenList1 = seedDb.EndBirth(births[4]);
            clinicContext.AddRange(childrenList1);
            clinicContext.SaveChanges();
        }
    }
}
