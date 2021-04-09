using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinic.Models
{
    public class RestRoom
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public Clinic BirthClinic { get; set; }
        public int BirthClinicId { get; set; }
        public List<Parent> Parents { get; set; }
    }
}
