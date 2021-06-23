using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Models
{
    public class CalcModel
    {
        public string Id { get; set; }
        public string RegisterName { get; set; }
        public string OperationName { get; set; }
        public float Value { get; set; }
    }
}
