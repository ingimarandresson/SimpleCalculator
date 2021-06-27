using Microsoft.EntityFrameworkCore;
using SimpleCalculator.Helpers.Data;
using SimpleCalculator.Models.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Helpers
{
    public class Calculator : ICalculator
    {
        private readonly CalcDbContext _context;

        public Calculator(CalcDbContext context)
        {
            _context = context;
        }
        public async Task Calculate(SimpleCalcVM model)
        {
            float _value = 0f;

            try
            {
                //Get all registers from database
                var _registers = await _context.Registers.ToListAsync();
                //Get selected operation
                var _operation = await _context.Operations.FirstOrDefaultAsync(x => x.Id == model.SelectedOperation);

                //Get first selected register from collection
                var _fReg = _registers.FirstOrDefault(x => x.Id == model.SelectedRegister);
           
                //Check if a second register is selected and set the value from it, if not value from value box is used
                if (!string.IsNullOrEmpty(model.SecondRegister))
                {
                    //Set current value from second selected register
                    _value = _registers.FirstOrDefault(x => x.Id == model.SecondRegister).Value;
                }
                else { _value = model.Value; }

                //Set values based on selected operation, here we can add operations.
                //This can be made more dynamic but for simplicity in this case I chose not to. 
                switch (_operation.Sign)
                {
                    case "+":
                        _fReg.Value += _value;
                        break;
                    case "-":
                        _fReg.Value -= _value;
                        break;
                    case "*":
                        _fReg.Value *= _value;
                        break;
                    default:
                        _fReg.Value = _value;
                        break;
                };

                //Update selected register with new value
                _context.Registers.Update(_fReg);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message); 
            }
        }
    }
}
