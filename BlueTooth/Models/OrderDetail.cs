using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int MatherialId { get; set; }

        public Matherial Matherial { get; set; }

        [Required]
        public int OrderHeaderId { get; set; }

        public OrderHeader OrderHeader { get; set; }
    }
}
