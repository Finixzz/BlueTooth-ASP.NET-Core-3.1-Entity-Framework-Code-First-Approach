using BlueTooth.Dtos;
using BlueTooth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.ViewModels
{
    public class UspostaviDijagnozuModel
    {
        public string  PacijentId { get; set; }

        public string DoktorId { get; set; }

        public int DijagnozaId { get; set; }

        public List<int> Usluge { get; set; }

        public string Komentar { get; set; }

    }
}
