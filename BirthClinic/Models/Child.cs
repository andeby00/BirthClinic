using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinic.Models
{
    public class Child
    {
        public int ChildId { get; set; }
        public string Gender { get; set; }
        public bool DeathAtBirth { get; set; }
        public Birth Birth { get; set; }
        public int BirthId { get; set; }
        public List<Parent> Parents { get; set; }
        
    }
}
