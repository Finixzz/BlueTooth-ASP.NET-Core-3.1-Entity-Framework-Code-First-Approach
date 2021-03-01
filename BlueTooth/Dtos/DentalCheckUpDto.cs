using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Dtos
{
    public class DentalCheckUpDto
    {
        public int Id { get; set; }

        [Required]
        public int AppointmentId { get; set; }


        [StringLength(150)]
        public string Description { get; set; }
    }
}
