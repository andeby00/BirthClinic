using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinic.Models
{
    public class Birth
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }       
        public Parent Parent { get; set; }
        public BirthRoom BirthRoom { get; set; }
        public int BirthRoomID { get; set; }
    }
}
