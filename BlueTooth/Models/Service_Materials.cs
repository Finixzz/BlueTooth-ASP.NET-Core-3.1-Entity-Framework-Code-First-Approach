using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models
{
    public class Service_Materials
    {
        public int ServiceId { get; set; }

        public Service Service { get; set; }

        public int MatherialId { get; set; }
        public Matherial  Matherial { get; set; }
    }
}
