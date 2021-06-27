using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Models.ViewModels
{
    public class PrintVM
    {
        public IEnumerable<SelectListItem> Registers { get; set; }

        [Required(ErrorMessage = "You must select a register to print!!")]
        public string SelectedRegister { get; set; }
    }
}
