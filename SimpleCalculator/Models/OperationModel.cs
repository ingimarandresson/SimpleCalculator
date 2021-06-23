using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Models
{
    public class OperationModel
    {
        public string Id { get; set; }
        public string OperationName { get; set; }
        public string Sign { get; set; }
        public string OperationMethod { get; set; }

        public bool IsActive { get; set; }
    }
}
