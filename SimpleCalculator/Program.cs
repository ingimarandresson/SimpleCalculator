using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SimpleCalculator.Helpers.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var _host = CreateHostBuilder(args).Build();

            //Find service layer within our scope for data seeding
            using (var _scope = _host.Services.CreateScope())
            {
                //GEt the instance of CalcDbContext in our service layer
                var _services = _scope.ServiceProvider;
                var _context = _services.GetRequiredService<CalcDbContext>();

                InitialCalcData.SyncFileDataAsync(_services); 
            }

            _host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
