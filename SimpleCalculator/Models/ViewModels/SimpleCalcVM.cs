using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimpleCalculator.Models.ViewModels
{
    public class SimpleCalcVM
    {
        public string Id { get; set; }
        public IEnumerable<SelectListItem> Registers { get; set; }

        public IEnumerable<SelectListItem> Operations { get; set; }

        [Required(ErrorMessage = "Register is required")]
        public string SelectedRegister { get; set; }

        [Required(ErrorMessage = "Operation is requred")]
        public string SelectedOperation { get; set; }

        public string SecondRegister { get; set; }

        [Required(ErrorMessage = "Value is required")]
        public float Value { get; set; }
    }
}
