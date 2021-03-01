using BlueTooth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.ViewModels
{
    public class UpostaviFakturuViewModel
    {
        public int PregledId { get; set; }

        public ApplicationUser Pacijent { get; set; }

        public List<Service> Usluge { get; set; }

        public float UkupnaCijena { get; set; }

        public UpostaviFakturuViewModel()
        {
            Usluge = new List<Service>();
            UkupnaCijena = 0;
        }

     
    }
}
