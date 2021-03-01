using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models
{
    public class Firma
    {
        public int Id { get; set; }

        [Required][StringLength(100)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefon { get; set; }

        [Required]
        [StringLength(15)]
        public string Fax { get; set; }

        [Required]
        [StringLength(100)]
        public string Adresa { get; set; }

    }
}
