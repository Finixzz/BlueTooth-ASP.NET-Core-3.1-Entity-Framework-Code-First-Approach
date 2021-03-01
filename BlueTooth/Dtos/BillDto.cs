using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Dtos
{
    public class BillDto
    {
        public int Id { get; set; }

        [Required]
        public int DentalCheckId { get; set; }

        [Required]
        public DateTime Time { get; set; }

        [Required]
        public float TotalPrice { get; set; }
    }
}
