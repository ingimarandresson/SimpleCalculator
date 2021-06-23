using SimpleCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Helpers.Data
{
    public static class InitialCalcData
    {
        public static async Task<List<OperationModel>> CreateOperations()
        {
            List<OperationModel> _operations = new()
            {
                new() { Id = Guid.NewGuid().ToString(), OperationName = "Add", Sign ="+", OperationMethod = "Add", IsActive = true },
                new() { Id = Guid.NewGuid().ToString(), OperationName = "Substract", Sign = "-", OperationMethod = "Subtract", IsActive = true },
                new() { Id = Guid.NewGuid().ToString(), OperationName = "Multiply", Sign = "*", OperationMethod = "Subtract", IsActive = true},
                new() { Id = Guid.NewGuid().ToString(), OperationName = " Devide", Sign = "/", OperationMethod = "Divition", IsActive = false}
            };

            return await Task.FromResult(_operations);
        }

        public static async Task<List<RegisterModel>> CreateRegisters()
        {
            List<RegisterModel> _registers = new()
            {
                new () { Id = Guid.NewGuid().ToString(), RegisterName = "Jupiter", IsActive = true },
                new() { Id = Guid.NewGuid().ToString(), RegisterName = "Mars", IsActive = true },
                new() { Id = Guid.NewGuid().ToString(), RegisterName = "Pluto", IsActive = false },
                new() { Id = Guid.NewGuid().ToString(), RegisterName = "Tatooine", IsActive = true },
                new() { Id = Guid.NewGuid().ToString(), RegisterName = "Death Star", IsActive = true }
            };

            return await Task.FromResult(_registers);
        }
    }
}
