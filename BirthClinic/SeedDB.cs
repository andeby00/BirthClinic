using System;
using System.Collections.Generic;
using System.IO;
using BirthClinic.DataAccess;
using BirthClinic.Models;

namespace BirthClinic
{
    public class SeedDB
    {
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

        public Shift GenerateShift(List<Clinician> clinincians, DateTime startTime)
        {
            Shift shift = new Shift()
            {
                StartTime = startTime,
                EndTime = startTime.AddDays(1), 
                Clinicians = clinincians,
            };

            return shift;
        }

        private static string GetRandomFirstName()
        {
            string firstName = "";
            var sr = new StreamReader(@"FirstNames.txt");
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
            var sr = new StreamReader(@"LastNames.txt");
            var r = new Random();

            for (int i = 0; i < r.Next(1, 200); i++)
            {
                lastName = sr.ReadLine();
            }

            return lastName;
        }
    }
}