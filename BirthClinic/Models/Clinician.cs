using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinic.Models
{
    public class Clinician
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public Clinic BirthClinic { get; set; }
        public int BirthClinicId { get; set; }
        public Shift Shift { get; set; }
        public int ShiftId { get; set; }
        public Birth Birth { get; set; }
        public int BirthId { get; set; }

    }
}
