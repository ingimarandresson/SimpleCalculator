using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var _registers = await InitialCalcData.CreateRegisters();
            var _operations = await InitialCalcData.CreateOperations();
            var _model = new SimpleCalcVM
            {
                Registers = new SelectList(_registers, "Id", "RegisterName"),
                Operations = new SelectList(_operations.Where(x => x.IsActive), "Id", "Sign")
            };

            _logger.LogTrace("Application started");
            ModelState.AddModelError("Me", "Testing Error");
            return View(_model);
        }

        public async Task<IActionResult> AddToCalc(SimpleCalcVM model)
        {
            return RedirectToAction(nameof(Index)); 
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
