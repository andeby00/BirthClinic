using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinicApp.Models
{
    public class BirthRoom
    {
        public int BirthRoomId { get; set; }
        public int RoomNumber { get; set; }
        public BirthClinic BirthClinic { get; set; }
        public int BirthClinicID { get; set; }
        public List<Birth> Birth { get; set; }
    }
}
