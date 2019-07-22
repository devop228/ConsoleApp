using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder();
            var configEnv = configBuilder
                .AddEnvironmentVariables(prefix: "CONSOLEAPP_")
                .Build();
            var env = configEnv["ENVIRONMENT"] ?? "Development";
            Console.WriteLine($"Curent environment is {env}");
            var configRoot = configBuilder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional:true, reloadOnChange:true)
                .AddJsonFile($"appsettings.{env}.json", optional:true, reloadOnChange:true)
                .AddEnvironmentVariables()
                .Build();

            Console.WriteLine($"setting1: {configRoot["setting1"]}");
            var envSect = configRoot.GetSection("env");
            if (envSect is null)
                Console.WriteLine("Can't find env section.");
            else    
                Console.WriteLine($"env:setting2: {configRoot["env:setting2"]}");
        }
    }
}
