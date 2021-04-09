using System;
using System.IO;
using BirthClinicApp.Models;

namespace BirthClinicApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");




            
            
        }


        public string GetRandomFirstName()
        {
            string firstName = "";
            var sr = new StreamReader(@"FirstName.txt");
            var r = new Random();
            
            for (int i = 0; i < r.Next(1,200); i++)
            {
                firstName = sr.ReadLine();
            }

            return firstName;
        }

        public string GetRandomLastName()
        {
            string lastName = "";
            var sr = new StreamReader(@"FirstName.txt");
            var r = new Random();

            for (int i = 0; i < r.Next(1, 200); i++)
            {
                lastName = sr.ReadLine();
            }

            return lastName;
        }

    }
}
