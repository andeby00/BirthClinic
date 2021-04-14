using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BirthClinic.Models
{
    public class Birth
    {
        public int Id { get; set; }
        public int? Ended { get; set; } //0 = ongoing birth, 1 = ended birth, null = not started yet
        public DateTime ScheduledTime { get; set; }
        public List<Parent> Parents { get; set; }
        public List<Child>? Children { get; set; }
        public List<Clinician>? Clinicians { get; set; }
        public BirthRoom BirthRoom { get; set; }
        public int BirthRoomID { get; set; }
        public MaternityRoom MaternityRoom { get; set; }
        public int MaternityRoomID { get; set; }
        public RestRoom RestRoom { get; set; }
        public int RestRoomID { get; set; }
    }
}
