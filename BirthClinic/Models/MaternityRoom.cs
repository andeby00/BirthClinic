using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinic.Models
{
    public class MaternityRoom
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public BirthClinc BirthClinic { get; set; }
        public int BirthClinicId {get;set;}
        public List<Parent> Parents { get; set; }


    }
}
