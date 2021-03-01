
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlueTooth.ViewModels
{
    public class RadnikCreateViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public string BirthDate { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(50)]
        [Required]
        public string Qualification { get; set; }

        public IFormFile CV { get; set; }

        public bool IsEmployed { get; set; }

        public string CVPath { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public RadnikCreateViewModel()
        {
            IsEmployed = true;
        }

    }
}
