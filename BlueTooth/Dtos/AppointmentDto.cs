using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }

        [Required]
        public string PatientId { get; set; }


        [Required]
        public DateTime Time { get; set; }

        [Required]
        public bool IsValid { get; set; }
    }
}
