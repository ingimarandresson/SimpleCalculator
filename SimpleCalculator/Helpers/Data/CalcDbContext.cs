using Microsoft.EntityFrameworkCore;
using SimpleCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Helpers.Data
{
    public class CalcDbContext : DbContext
    {
        public CalcDbContext(DbContextOptions<CalcDbContext> options) : base(options)
        {

        }
        public DbSet<RegisterModel> Registers { get; set; }
        public DbSet<OperationModel> Operations { get; set; }

        public DbSet<CalcModel> CalcModels { get; set; }
    }
}
