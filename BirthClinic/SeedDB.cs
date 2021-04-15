using System;
using System.Collections.Generic;
using System.IO;
using BirthClinic.DataAccess;
using BirthClinic.Models;

namespace BirthClinic
{
    public class SeedDB
    {
        private string path = @"..\..\..\";

        private string GetRandomFirstName()
        {
            string firstName = "";
            var sr = new StreamReader($"{path}FirstNames.txt");
            var r = new Random();

            for (int i = 0; i < r.Next(1, 200); i++)
            {
                firstName = sr.ReadLine();
            }

            return firstName;
        }

        private string GetRandomLastName()
        {
            string lastName = "";
            var sr = new StreamReader($"{path}LastNames.txt");
            var r = new Random();

            for (int i = 0; i < r.Next(1, 200); i++)
            {
                lastName = sr.ReadLine();
            }

            return lastName;
        }

        public List<Clinician> GenerateClinicians()
        {
            List<Clinician> list = new List<Clinician>();

            Context clinicContext = new Context();

            for (int i = 0; i < 10; i++)
            {
                var temp = new Midwife()
                {
                    FirstName = GetRandomFirstName(),
                    LastName = GetRandomLastName(),
                    DoB = DateTime.Today
                };

                list.Add(temp);
            }

            for (int i = 0; i < 4; i++)
            {
                var temp = new Secretary()
                {
                    FirstName = GetRandomFirstName(),
                    LastName = GetRandomLastName(),
                    DoB = DateTime.Today
                };

                list.Add(temp);
            }

            for (int i = 0; i < 20; i++)
            {
                var temp = new Nurse()
                {
                    FirstName = GetRandomFirstName(),
                    LastName = GetRandomLastName(),
                    DoB = DateTime.Today
                };

                list.Add(temp);
            }

            for (int i = 0; i < 5; i++)
            {
                var temp = new Doctor()
                {
                    FirstName = GetRandomFirstName(),
                    LastName = GetRandomLastName(),
                    DoB = DateTime.Today
                };

                list.Add(temp);
            }

            for (int i = 0; i < 20; i++)
            {
                var temp = new SocialHealthAss()
                {
                    FirstName = GetRandomFirstName(),
                    LastName = GetRandomLastName(),
                    DoB = DateTime.Today
                };

                list.Add(temp);
            }
            return list;
        }

        public Shift GenerateShift(List<Clinician> clinicians, DateTime startTime)
        {
            Shift shift = new Shift()
            {
                StartTime = startTime,
                EndTime = startTime.AddDays(1), 
                Clinicians = clinicians,
            };

            return shift;
        }

        public List<Child> GenerateBornChildren(Birth birth, List<Parent> parents)
        {
            birth.Ended = 1;
            Random random = new Random();
            List<Child> children = new List<Child>();

            for (int i = 0; i < random.Next(1,3); i++)
            {
                int rand = random.Next(0, 99);

                Child child = new Child()
                {
                    Gender = "F", 
                    DeathAtBirth = (rand == 0 ? true : false),
                    Parents = parents,
                    Birth = birth
                };
                children.Add(child);
            }
            
            return children;
        }

        public Parent GenerateParent()
        {
            Parent parent = new Parent()
            {
                FirstName = GetRandomFirstName(),
                LastName = GetRandomLastName(),
                DoB = DateTime.Today
            };

            return parent;
        }

        public List<MaternityRoom> GenerateMaternityRooms()
        {
            List<MaternityRoom> list = new List<MaternityRoom>();
            for (int i = 0; i < 22; i++)
            {
                var temp = new MaternityRoom()
                {
                    RoomNumber = i
                };
                list.Add(temp);
            }

            return list;
        }
        public List<RestRoom> GenerateRestRooms()
        {
            List<RestRoom> list = new List<RestRoom>();
            for (int i = 0; i < 5; i++)
            {
                var temp = new RestRoom()
                {
                    RoomNumber = i
                };
                list.Add(temp);
            }

            return list;
        }
        public List<BirthRoom> GenerateBirthRooms()
        {
            List<BirthRoom> list = new List<BirthRoom>();
            for (int i = 0; i < 15; i++)
            {
                var temp = new BirthRoom()
                {
                    RoomNumber = i
                };
                list.Add(temp);
            }

            return list;
        }

        public Birth ScheduleBirth(List<Clinician> clinicians, List<Parent> parents, BirthRoom birthRoom, 
                                            MaternityRoom maternityRoom, RestRoom restRoom, DateTime startTime)
        {
            Birth birth = new Birth()
            {
                Clinicians = clinicians,
                Parents = parents,
                BirthRoom = birthRoom,
                RestRoom = restRoom,
                MaternityRoom = maternityRoom,
                ScheduledTime = startTime,
            };

            return birth;
        }

        public void StartBirth(Birth birth)
        {
            birth.Ended = 0;
        }

        public List<Child> EndBirth(Birth birth)
        {
            birth.Ended = 1;
            
            birth.Children = GenerateBornChildren(birth, birth.Parents);
            return birth.Children;
        }


        public void SeedData(Context clinicContext)
        {
            Console.WriteLine("Creating data and seeding it to the db . . .\n\n");
            
            List<Clinician> clinicians1 = GenerateClinicians();
            clinicContext.AddRange(clinicians1);
            List<Clinician> clinicians2 = GenerateClinicians();
            clinicContext.AddRange(clinicians2);
            List<Clinician> clinicians3 = GenerateClinicians();
            clinicContext.AddRange(clinicians3);
            List<Clinician> clinicians4 = GenerateClinicians();
            clinicContext.AddRange(clinicians4);
            List<Clinician> clinicians5 = GenerateClinicians();
            clinicContext.AddRange(clinicians5);
            List<Clinician> clinicians6 = GenerateClinicians();
            clinicContext.AddRange(clinicians6);

            List<Shift> shiftList = new List<Shift>();
            shiftList.Add(GenerateShift(clinicians1, DateTime.Today));
            shiftList.Add(GenerateShift(clinicians2, DateTime.Today.AddDays(1)));
            shiftList.Add(GenerateShift(clinicians3, DateTime.Today.AddDays(2)));
            shiftList.Add(GenerateShift(clinicians4, DateTime.Today.AddDays(3)));
            shiftList.Add(GenerateShift(clinicians5, DateTime.Today.AddDays(4)));
            shiftList.Add(GenerateShift(clinicians6, DateTime.Today.AddDays(6)));
            clinicContext.AddRange(shiftList);

            List<Parent> parents = new List<Parent>();
            for (int i = 0; i < 10; i++)
            {
                parents.Add(GenerateParent());
            }
            clinicContext.AddRange(parents);

            List<BirthRoom> birthRooms = GenerateBirthRooms();
            List<MaternityRoom> maternityRooms = GenerateMaternityRooms();
            List<RestRoom> restRooms = GenerateRestRooms();
            clinicContext.AddRange(birthRooms);
            clinicContext.AddRange(maternityRooms);
            clinicContext.AddRange(restRooms);

            List<Birth> births = new List<Birth>();

            births.Add(ScheduleBirth(new List<Clinician>() { clinicians1[0], clinicians1[1], clinicians1[2], clinicians1[3], clinicians1[4], clinicians1[5], clinicians1[6], clinicians1[7], clinicians1[8], clinicians1[9] }, new List<Parent>() { parents[0], parents[1] }, birthRooms[0], maternityRooms[0], restRooms[0], DateTime.Now));
            births.Add(ScheduleBirth(new List<Clinician>() { clinicians4[0], clinicians4[1], clinicians4[2], clinicians4[3], clinicians4[4], clinicians4[5], clinicians4[6], clinicians4[7], clinicians4[8], clinicians4[9] }, new List<Parent>() { parents[6], parents[7] }, birthRooms[0], maternityRooms[0], restRooms[0], DateTime.Today.AddDays(3)));
            births.Add(ScheduleBirth(new List<Clinician>() { clinicians3[0], clinicians3[1], clinicians3[2], clinicians3[3], clinicians3[4], clinicians3[5], clinicians3[6], clinicians3[7], clinicians3[8], clinicians3[9] }, new List<Parent>() { parents[2], parents[3] }, birthRooms[1], maternityRooms[1], restRooms[1], DateTime.Today.AddDays(2)));
            births.Add(ScheduleBirth(new List<Clinician>() { clinicians5[0], clinicians5[1], clinicians5[2], clinicians5[3], clinicians5[4], clinicians5[5], clinicians5[6], clinicians5[7], clinicians5[8], clinicians5[9] }, new List<Parent>() { parents[4], parents[5] }, birthRooms[2], maternityRooms[2], restRooms[2], DateTime.Today.AddDays(9)));
            births.Add(ScheduleBirth(new List<Clinician>() { clinicians2[0], clinicians2[1], clinicians2[2], clinicians2[3], clinicians2[4], clinicians2[5], clinicians2[6], clinicians2[7], clinicians2[8], clinicians2[9] }, new List<Parent>() { parents[8], parents[9] }, birthRooms[3], maternityRooms[3], restRooms[3], DateTime.Today));
            clinicContext.AddRange(births);

            StartBirth(births[0]);
            List<Child> childrenList1 = EndBirth(births[4]);
            clinicContext.AddRange(childrenList1);
            clinicContext.SaveChanges();
        }
    }
}