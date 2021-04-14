using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinic.Models
{
    public class BirthRoom
    {
        public int BirthRoomId { get; set; }
        public int RoomNumber { get; set; }
        public List<Birth>? Births { get; set; }
    }
}
