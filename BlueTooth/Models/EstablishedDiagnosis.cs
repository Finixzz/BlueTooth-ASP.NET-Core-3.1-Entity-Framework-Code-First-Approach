using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models
{
    public class EstablishedDiagnosis
    {
        public int Id { get; set; }

        [Required]
        public int DentalCheckUpId { get; set; }

        public DentalCheckUp DentalCheckUp { get; set; }

        [Required]
        public int DiagnoseId { get; set; }

        public Diagnose Diagnose { get; set; }



    }
}
