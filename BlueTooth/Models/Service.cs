﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models
{
    public class Service
    {
        public int Id { get; set; }


        [Required][StringLength(100)]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }
    }
}
