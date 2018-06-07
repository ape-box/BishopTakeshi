using System;
using System.IO;
using System.Runtime.Loader;
using System.Threading;
using BishopTakeshi.Service.Host.Host;
using Microsoft.Extensions.Configuration;

namespace BishopTakeshi.Service.ConsoleHost
{
    class Program
    {
        private static ServiceHost service;

        private static IConfigurationRoot Configuration;

        private static string Setting(string name)
            => Environment.GetEnvironmentVariable(name) ?? Configuration[name];

        static void Main(string[] args)
        {
            try
            {
                AssemblyLoadContext.Default.Unloading += SigTermEventHandler;
                Console.CancelKeyPress += CancelHandler;

                var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                    .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: false)
                    .AddEnvironmentVariables();

                Configuration = builder.Build();

                service = new ServiceHost(Setting);

                while (true)
                {
                    Thread.Sleep(2000);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static void SigTermEventHandler(AssemblyLoadContext obj)
        {
            System.Console.WriteLine("Unloading ...");
        }

        private static void CancelHandler(object sender, ConsoleCancelEventArgs e)
        {
            System.Console.WriteLine("Exiting ...");
            service.Dispose();
            System.Console.WriteLine("Service stopped!");
            System.Environment.Exit(0);
        }
    }
}
