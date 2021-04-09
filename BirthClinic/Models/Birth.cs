using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BirthClinicApp.Models
{
    public class Birth
    {
        public int Id { get; set; }
        public int? Ended { get; set; } //0 = ongoing birth, 1 = ended birth, null = not started yet
        public DateTime TimeStamp { get; set; }       
        public List<Parent> Parent { get; set; }
        public List<Child> Childs { get; set; }
        public BirthRoom BirthRoom { get; set; }
        public int BirthRoomID { get; set; }
    }
}
