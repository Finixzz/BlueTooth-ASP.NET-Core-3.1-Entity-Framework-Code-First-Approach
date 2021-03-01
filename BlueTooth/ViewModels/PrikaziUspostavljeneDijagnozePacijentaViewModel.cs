using BlueTooth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.ViewModels
{
    public class PrikaziUspostavljeneDijagnozePacijentaViewModel
    {
        public List<ApplicationUser> Doktori { get; set; }

        public DateTime Datum { get; set; }

        public string Dijagnoza { get; set; }

        public string Napomena { get; set; }

        public List<Service> Usluge { get; set; }

        public PrikaziUspostavljeneDijagnozePacijentaViewModel()
        {
            Usluge = new List<Service>();
            Doktori = new List<ApplicationUser>();
        }
    }
}
