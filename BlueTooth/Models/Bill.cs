using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models
{
    public class Bill
    {
        public int Id { get; set; }

        [Required]
        public int DentalCheckId { get; set; }

        public DentalCheckUp DentalCheck { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public float TotalPrice { get; set; }
    }
}
