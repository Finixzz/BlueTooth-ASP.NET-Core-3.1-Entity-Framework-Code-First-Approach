using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models
{
    public class DentalCheck_Worker
    {
        [Required]
        public int DentalCheckUpId { get; set; }

        public DentalCheckUp DentalCheckUp { get; set; }

        [Required]
        public string WorkerId { get; set; }

        public Worker Worker { get; set; }
    }
}
