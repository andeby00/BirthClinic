using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinic.Models
{
    public class BirthRoom
    {
        public int BirthRoomId { get; set; }
        public int RoomNumber { get; set; }
        public BirthClinc BirthClinc { get; set; }
        public int BirthClinitID { get; set; }
        public Birth Birth { get; set; }
    }
}
