using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Helpers
{
    public interface IFileStorageHelper
    {
        Task UploadFile();
    }
}
