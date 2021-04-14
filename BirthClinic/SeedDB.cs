using System;
using System.Collections.Generic;
using System.IO;
using BirthClinic.DataAccess;
using BirthClinic.Models;

namespace BirthClinic
{
    public class SeedDB
    {

        private static string GetRandomFirstName()
        {
            string firstName = "";
            var sr = new StreamReader(@"..\..\..\..\FirstNames.txt");
            var r = new Random();

            for (int i = 0; i < r.Next(1, 200); i++)
            {
                firstName = sr.ReadLine();
            }

            return firstName;
        }

        private static string GetRandomLastName()
        {
            string lastName = "";
            var sr = new StreamReader(@"..\..\..\..\LastNames.txt");
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

    }
}