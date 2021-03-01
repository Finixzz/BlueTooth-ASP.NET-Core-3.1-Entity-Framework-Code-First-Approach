using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models
{
    public class _DentalCheckServices
    {
        public int DentalCheckID { get; set; }

        public List<int> Services { get; set; }

        public _DentalCheckServices()
        {
            Services = new List<int>();
        }
    }
}
