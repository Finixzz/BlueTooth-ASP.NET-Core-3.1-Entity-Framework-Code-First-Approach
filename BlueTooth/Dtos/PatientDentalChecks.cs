using BlueTooth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Dtos
{
    public class PatientDentalChecks
    {
        public ApplicationUser Pacijent { get; set; }

        public List<int> AppointmentList { get; set; }

        public PatientDentalChecks()
        {
            AppointmentList = new List<int>();
        }
    }
}
