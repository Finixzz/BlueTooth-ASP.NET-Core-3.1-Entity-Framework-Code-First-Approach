﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Dtos
{
    public class RatingDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }


        [Required]
        [Range(1, 5)]
        public int Mark { get; set; }

        [Required]
        [StringLength(250)]
        public string Comment { get; set; }
    }
}
