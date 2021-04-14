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

            Console.WriteLine("Seed DB with data: Press a");
            Console.WriteLine("--------------------------");
            Console.WriteLine("View 1 - Planned births for next 3 days: Press 1");
            Console.WriteLine("--------------------------");
            Console.WriteLine("View 2 - Available rooms and clinicians for the next 5 days: Press 2");
            Console.WriteLine("--------------------------");
            Console.WriteLine("View 3 - Current births: Press 3");
            Console.WriteLine("--------------------------");
            Console.WriteLine("View 4 - Maternity rooms and 4h rest rooms in use with the parents and child/children: Press 4");
            Console.WriteLine("--------------------------");
            Console.WriteLine("View 5 - Planned births and its reserved rooms: Press 5");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Exit: Press x");
            Console.WriteLine("--------------------------");

            SeedDB seedDB = new SeedDB();
            Views views = new Views(); 
            var context = new Context();

            while (true)
            {
                switch(Console.ReadKey().Key)
                {
                    case ConsoleKey.A:
                        seedDB.SeedData(context);
                        break;

                    case ConsoleKey.D1:
                        views.viewPlannedBirths(context);
                        break;

                    case ConsoleKey.D2:
                        views.viewAvailableCliniciansAndRooms(context);
                        break;

                    case ConsoleKey.D3:
                        views.viewOngoingBirths(context);
                        break;

                    case ConsoleKey.D4:
                        views.viewOccupiedMaternityAndRest(context);
                        break;

                    case ConsoleKey.D5:
                        views.viewSpecifiedBirth(context);
                        break;

                    case ConsoleKey.X:
                        System.Console.WriteLine("Exiting....");
                        return;

                    default:
                        System.Console.WriteLine("Unknown command");
                        break;
                }
            }  
        }
    }
}
