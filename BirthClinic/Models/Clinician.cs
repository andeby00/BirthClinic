﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinicApp.Models
{
    public class Clinician
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public BirthClinic BirthClinic { get; set; }
        public int BirthClinicId { get; set; }

    }
}
