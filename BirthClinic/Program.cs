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

            List<Shift> shiftList = new List<Shift>();                                          
            shiftList.Add(seedDb.GenerateShift(clinicianList1, DateTime.Today));
            shiftList.Add(seedDb.GenerateShift(clinicianList2, DateTime.Today.AddDays(1)));
            shiftList.Add(seedDb.GenerateShift(clinicianList3, DateTime.Today.AddDays(2)));
            shiftList.Add(seedDb.GenerateShift(clinicianList4, DateTime.Today.AddDays(3)));
            shiftList.Add(seedDb.GenerateShift(clinicianList5, DateTime.Today.AddDays(4)));
            clinicContext.AddRange(shiftList);

            List<Parent> parents = new List<Parent>();          ////code below this hasnt been run 
            parents.Add(seedDb.GenerateParent());
            parents.Add(seedDb.GenerateParent());
            parents.Add(seedDb.GenerateParent());
            parents.Add(seedDb.GenerateParent());
            parents.Add(seedDb.GenerateParent());
            parents.Add(seedDb.GenerateParent());

            seedDb.GenerateRooms(clinicContext);

            List<Birth> births = new List<Birth>();

            //births.Add(seedDb.GenerateScheduledBirth(clinicianList1, new List<Parent>(){  parents[1] }, clinicContext.birthRoom.[0], DateTime.Today.AddDays(6)));


            clinicContext.SaveChanges();
            
        }
    }

    
}
