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
        public BirthRoom BirthRoom { get; set; }
        public RestRoom RestRoom { get; set; }
        public MaternityRoom MaternityRoom { get; set; }
        
    }
}
