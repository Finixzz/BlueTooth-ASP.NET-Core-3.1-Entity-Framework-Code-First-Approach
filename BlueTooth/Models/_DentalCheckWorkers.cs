using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models
{
    public class _DentalCheckWorkers
    {
        public int DentalCheckUpId { get; set; }

        //Dental workers that were present during dental check up
        [Required]
        public List<string> IdList { get; set; }

        public _DentalCheckWorkers()
        {
            IdList = new List<string>();
        }
    }
}
