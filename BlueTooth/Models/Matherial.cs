using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models
{
    public class Matherial
    {
        public int Id { get; set; }

        [Required][StringLength(100)]
        public string Name { get; set; }

        [Required]
        public float UnitPrice { get; set; }

        [Required]
        public int UnitsInStock { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
