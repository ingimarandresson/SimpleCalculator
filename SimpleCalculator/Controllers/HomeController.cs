using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleCalculator.Helpers.Data;
using SimpleCalculator.Models;
using SimpleCalculator.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CalcDbContext _context;
        private readonly ICalculator _calculator;

        public HomeController(ILogger<HomeController> logger, CalcDbContext context, ICalculator calculator)
        {
            _logger = logger;
            _context = context;
            _calculator = calculator;
        }

        public async Task<IActionResult> Index()
        {
            var _model = await CreateIndexModel();

            _logger.LogInformation("Application started");
            return View(_model);
        }

        public async Task<IActionResult> AddToCalc(SimpleCalcVM model)
        {
            if (!ModelState.IsValid)
                ModelState.AddModelError("", "Input data is not valid");
            try
            {
                //Send r-operation to calculation
                await _calculator.Calculate(model);
                _logger.LogInformation("Calculation copleted and selected register updated");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", $"Error: {ex.Message }");
                _logger.LogError($"Error in calculating and updateing selected register: {ex.Message}");
            }
            //Get latest operational value
            var _reg = await _context.Registers.FirstOrDefaultAsync(x => x.Id == model.SelectedRegister); 

            //Set display value for latest operation
            TempData["regValue"] = $"Register: {_reg.RegisterName}, Value: {_reg.Value}";  

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<SimpleCalcVM> CreateIndexModel()
        {
            //Get registers from database
            var _registers = await _context.Registers.ToListAsync();
            var _operations = await _context.Operations.ToListAsync();

            //Get registers from InitialCalcData
            // var _registers = await InitialCalcData.CreateRegisters();
            // var _operations = await InitialCalcData.CreateOperations();

            var _model = new SimpleCalcVM
            {
                Registers = new SelectList(_registers, "Id", "RegisterName"),
                Operations = new SelectList(_operations.Where(x => x.IsActive), "Id", "Sign")
            };

            return _model;
        }
    }
}
