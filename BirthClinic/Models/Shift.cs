using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinic.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Clinician> Clinicians { get; set; }
        public Clinic Clinic { get; set; }
        public int ClinicId { get; set; }

    }
}
