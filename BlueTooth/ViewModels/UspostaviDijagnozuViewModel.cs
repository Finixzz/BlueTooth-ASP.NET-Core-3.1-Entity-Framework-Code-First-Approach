using BlueTooth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.ViewModels
{
    public class UspostaviDijagnozuViewModel
    {

        public List<Diagnose> Diagnoses { get; set; }

        public List<Service> Services { get; set; }

        public List<ApplicationUser> Patients { get; set; }

        public UspostaviDijagnozuViewModel()
        {
            Diagnoses = new List<Diagnose>();
            Services = new List<Service>();
            Patients = new List<ApplicationUser>();
        }
    }
}
