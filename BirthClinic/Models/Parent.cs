using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinic.Models
{
    public class Parent
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public List<Child> Child { get; set; }
        public Birth Birth { get; set; }
    }
}
