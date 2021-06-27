using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Models
{
    public class RegisterModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression("^[a-zA-Z0-9]+$", ErrorMessage = "The password can only contain alphanumeric character")]
        [Display(Name = "Register")]
        public string RegisterName { get; set; }

        [Required(ErrorMessage = "Value cannot be null")]
        public float Value { get; set; }
    }
}
