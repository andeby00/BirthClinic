using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinic.Models
{
    public class Birth
    {
        public int BirthId { get; set; }
        public DateTime TimeStamp { get; set; }
        
        public Parent parent { get; set; }
    }
}
