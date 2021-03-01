using BlueTooth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.ViewModels
{
    public class PrikaziUspostavljeneDijagnozeViewModel
    {
        public ApplicationUser Pacijent { get; set; }

        public DateTime Datum { get; set; }

        public string Dijagnoza { get; set; }

        public string Napomena { get; set; }

        public List<Service> Usluge { get; set; }

        public PrikaziUspostavljeneDijagnozeViewModel()
        {
            Usluge = new List<Service>();
        }
    }
}
