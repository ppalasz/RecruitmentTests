using DiamondKata.Services;
using DiamondKata.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DiamondKata
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();

            var diamondService = serviceProvider.GetService<IDiamondService>() 
                ?? throw new Exception($"ID error: {nameof(DiamondService)} is null");

            if (args.Length != 1 || args[0].Length != 1 || !Char.IsLetter(args[0][0]))
            {
                Console.WriteLine("Provide a single alphabet letter as an argument");
                return;
            }

            try
            {
                diamondService.PrintDiamond(args[0][0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }       

        private static ServiceProvider ConfigureServices()
        {            
            var services = new ServiceCollection();
            services.AddSingleton<IDiamondService, DiamondService>();
            return services.BuildServiceProvider();
        }
    }
}
