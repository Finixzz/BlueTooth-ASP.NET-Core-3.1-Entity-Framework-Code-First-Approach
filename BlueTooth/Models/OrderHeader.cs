using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models
{
    public class OrderHeader
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int FirmaId { get; set; }
        public Firma Firma { get; set; }

        public string VlasnikOrdinacijeId { get; set; }

        public ApplicationUser VlasnikOrdinacije { get; set; }
    }
}
