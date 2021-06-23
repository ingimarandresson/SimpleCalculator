using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator.Helpers
{
    public class FileStorageHelper : IFileStorageHelper
    {
        public readonly IWebHostEnvironment _env;
        public FileStorageHelper(IWebHostEnvironment env)
        {
            _env = env;
        }
        public Task UploadFile()
        {
            var _root = _env.WebRootPath; 
            throw new NotImplementedException();
        }
    }
}
