using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models
{
    public class DentalCheck_Service
    {
        public int DentalCheckID { get; set; }

        public DentalCheckUp DentalCheck { get; set; }

        public int ServiceID { get; set; }

        public Service Service { get; set; }
    }
}
