using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimpleCalculator.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.Helpers.Data
{
    public static class InitialCalcData
    {
        /// <summary>
        /// LOad data from file to database
        /// </summary>
        /// <param name="service"></param>
        /// <returns></returns>
        public static async Task SyncFileDataAsync(IServiceProvider service)
        {
            using (var _context = new CalcDbContext(service.GetRequiredService<DbContextOptions<CalcDbContext>>()))
            {
                if(_context.Registers.Any())
                {
                    return; // Database has been seeded
                }

                //Read file into reader
                var _reader = new StreamReader(@"wwwroot\Files\RegisterData.csv", Encoding.GetEncoding("iso-8859-1"));
                List<RegisterModel> _registers = null; 

                if(_reader != null)
                {
                    using (var _csv = new CsvReader(_reader, CultureInfo.InvariantCulture))
                    {
                        //PArse Register from csv file to RegisterModel objects
                        _registers = _csv.GetRecords<RegisterModel>().ToList(); 
                    };
                }
                else
                {
                    //If file is not read we populate registers from seed data
                    _registers = await CreateRegisters();
                }

                //Add registers and operations to database
                await _context.Registers.AddRangeAsync(_registers);
                await _context.Operations.AddRangeAsync(await CreateOperations()); 
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Creates available operations
        /// </summary>
        /// <returns>List<OperationModel> for usage in UI</OperationModel></returns>
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

        /// <summary>
        /// Seed register data in case we are unable to read from file
        /// </summary>
        /// <returns></returns>
        public static async Task<List<RegisterModel>> CreateRegisters()
        {
            List<RegisterModel> _registers = new()
            {
                new () { Id = Guid.NewGuid().ToString(), RegisterName = "Jupiter", Value = 20 },
                new() { Id = Guid.NewGuid().ToString(), RegisterName = "Mars", Value = 340 },
                new() { Id = Guid.NewGuid().ToString(), RegisterName = "Pluto", Value = 120.35f },
                new() { Id = Guid.NewGuid().ToString(), RegisterName = "Tatooine", Value = 345.03f },
                new() { Id = Guid.NewGuid().ToString(), RegisterName = "Death Star",Value = 1000340 }
            };

            return await Task.FromResult(_registers);
        }
    }
}
