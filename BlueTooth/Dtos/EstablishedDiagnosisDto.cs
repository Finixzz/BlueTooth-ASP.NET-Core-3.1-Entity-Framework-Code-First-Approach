using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Dtos
{
    public class EstablishedDiagnosisDto
    {
        public int Id { get; set; }

        [Required]
        public int DentalCheckUpId { get; set; }


        [Required]
        public int DiagnoseId { get; set; }


    }
}
