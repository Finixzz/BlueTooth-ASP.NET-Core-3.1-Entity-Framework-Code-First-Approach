using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models
{
    public class DentalCheckUp
    {
        public int Id { get; set; }

        [Required]
        public int AppointmentId { get; set; }

        public Appointment Appointment { get; set; }

        [StringLength(150)]
        public string Description { get; set; }
    }
}
