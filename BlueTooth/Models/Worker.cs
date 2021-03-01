using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.Models
{
    public class Worker
    {
        [ForeignKey(nameof(ApplicationUser))]
        public string Id { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        [Required][StringLength(50)]
        public string Qualification { get; set; }

        public string CV { get; set; }

        [Required]
        public bool IsEmployed { get; set; }

        public Worker()
        {
            IsEmployed = true;
        }

    }
}
