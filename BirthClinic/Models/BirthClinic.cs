using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinicApp.Models
{
    public class BirthClinic
    {

        public int ID { get; set; }
        public string ClinicName { get; set; }
        public string Address { get; set; }
        public List<Clinician> Clinicians { get; set; }
        public List<BirthRoom> BirthRooms { get; set; }
        public List<MaternityRoom> MaternityRooms { get; set; }
        public List<RestRoom> RestRooms { get; set; }
    }
}
