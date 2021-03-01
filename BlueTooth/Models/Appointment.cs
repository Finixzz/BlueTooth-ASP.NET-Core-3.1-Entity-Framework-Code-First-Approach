using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string  PatientId { get; set; }

        public  ApplicationUser Patient { get; set; }

        public DateTime Time { get; set; }

        public bool IsValid { get; set; }
    }
}
