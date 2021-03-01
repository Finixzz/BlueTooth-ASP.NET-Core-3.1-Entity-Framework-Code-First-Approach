using BlueTooth.Dtos;
using BlueTooth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.ViewModels
{
    public class PrikaziDetaljeFaktureViewModel : BillDto
    {
        public List<Service> Usluge { get; set; }

        public PrikaziDetaljeFaktureViewModel()
        {
            Usluge = new List<Service>();
        }
    }
}
