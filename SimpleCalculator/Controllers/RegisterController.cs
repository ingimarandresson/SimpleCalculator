using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SimpleCalculator.Helpers.Data;
using SimpleCalculator.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Controllers
{
    public class RegisterController : Controller
    {
        private readonly CalcDbContext _context;
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(CalcDbContext context, ILogger<RegisterController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Register
        public async Task<IActionResult> Index()
        {
            return View(await _context.Registers.ToListAsync());
        }

        // GET: Register/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerModel = await _context.Registers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registerModel == null)
            {
                return NotFound();
            }

            return View(registerModel);
        }

        // GET: Register/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Register/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegisterName,Value")] RegisterModel registerModel)
        {
            registerModel.Id = Guid.NewGuid().ToString(); 

            if (ModelState.IsValid)
            {
                _context.Add(registerModel);
                await _context.SaveChangesAsync();

                _logger.LogInformation($"Register: {registerModel.RegisterName} has been created.");

                return RedirectToAction(nameof(Index));
            }
            return View(registerModel);
        }

        // GET: Register/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerModel = await _context.Registers.FindAsync(id);
            if (registerModel == null)
            {
                return NotFound();
            }
            return View(registerModel);
        }

        // POST: Register/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,RegisterName,Value")] RegisterModel registerModel)
        {
            if (id != registerModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registerModel);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation($"Register: {registerModel.RegisterName} has been updated");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisterModelExists(registerModel.Id))
                    {
                        _logger.LogError($"Error: Unable to find register: {registerModel.RegisterName}"); 
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(registerModel);
        }

        // GET: Register/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registerModel = await _context.Registers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registerModel == null)
            {
                return NotFound();
            }

            return View(registerModel);
        }

        // POST: Register/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var registerModel = await _context.Registers.FindAsync(id);
            _context.Registers.Remove(registerModel);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Register: {registerModel.RegisterName} has been deleted"); 

            return RedirectToAction(nameof(Index));
        }

        private bool RegisterModelExists(string id)
        {
            return _context.Registers.Any(e => e.Id == id);
        }
    }
}
