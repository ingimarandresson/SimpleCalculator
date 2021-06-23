using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Models.ViewModels
{
    public class SimpleCalcVM
    {
        public IEnumerable<SelectListItem> Registers { get; set; }
        public IEnumerable<SelectListItem> Operations { get; set; }

        [Required]
        public string SelectedRegister { get; set; }

        [Required]
        public string SelectedOperation { get; set; }

        [Required]
        public float Value { get; set; }
    }
}
