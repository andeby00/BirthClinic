using System;
using System.Collections.Generic;
using System.Text;

namespace BirthClinic.Models
{
    public class BirthClinc
    {
        public int ID { get; set; }
        public string ClinicName { get; set; }
        public string? Address { get; set; }
        public List<Clinician> Clinicians { get; set; }
        //Skal der være clinicianID i denne klasse, når den skal have en FK til Clinicians i tabellen?

        public List<BirthRoom> BirthRooms { get; set; }
        //Skal der være BirthRoomID i denne klasse, når den skal have en FK til BirthRoom i tabellen?

        public List<MaternityRoom> MaternityRooms { get; set; }
        //Skal der være MaternityRoomID i denne klasse, når den skal have en FK til MaternityRoom i tabellen?

        public List<RestRoom> RestRooms { get; set; }
        //Skal der være RestRoomID i denne klasse, når den skal have en FK til RestRoom i tabellen?

    }
}
