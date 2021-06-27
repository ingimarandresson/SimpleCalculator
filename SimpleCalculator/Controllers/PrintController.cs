using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleCalculator.Helpers.Data;
using SimpleCalculator.Models.ViewModels;
using System;
using System.Threading.Tasks;

namespace SimpleCalculator.Controllers
{
    public class PrintController : Controller
    {
        private readonly CalcDbContext _context;
        private readonly ILogger<PrintController> _logger;

        public PrintController(CalcDbContext context, ILogger<PrintController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var _registers = await _context.Registers.ToListAsync();

            var _model = new PrintVM
            {
                Registers = new SelectList(_registers, "Id", "RegisterName")
            };

            return View(_model);
        }

        public async Task<IActionResult> PrintRegister(PrintVM model)
        {
            if (!ModelState.IsValid)
                ModelState.AddModelError("", "No register selected");

            try
            {
                //Get selected register
                var _selectedRegister = await _context.Registers.FirstOrDefaultAsync(x => x.Id == model.SelectedRegister);

                //Display value from the selected register
                TempData["regValue"] = $"Selected Register: {_selectedRegister.RegisterName}, Current value: {_selectedRegister.Value}";
                _logger.LogInformation("Selected register has been printed");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}"); 
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
