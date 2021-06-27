using SimpleCalculator.Models;
using SimpleCalculator.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Helpers.Data
{
    public interface ICalculator
    {
        Task Calculate(SimpleCalcVM model);
    }
}
