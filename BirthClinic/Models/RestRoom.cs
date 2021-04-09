using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinicApp.Models
{
    public class RestRoom
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public BirthClinic BirthClinic { get; set; }
        public int BirthClinicId { get; set; }
        public List<Parent> Parents { get; set; }
    }
}
