using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinic.Models
{
    public class Clinician
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }

    }
}
