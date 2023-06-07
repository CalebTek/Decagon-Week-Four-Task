using System;
using Bank.Model.Common.Implementations;
using Bank.Model.Common.Models;
using Bank.Model.Common.Interfaces;
using System.Security.Authentication.ExtendedProtection;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Model
{

    public class Program
    {
        public static void Main()
        {

           var services = new ServiceCollection();
           ConfigureServices(services);
            services
                .AddScoped<IBank, Banks>()
                .BuildServiceProvider()
                .GetService<Banks>()
                .Start();
                
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IPrinter, Printer>();
            services.AddScoped<IValidateInput, ConsoleUserInput>();
            services.AddScoped<IDisplayUI, DisplayUI>();
            services.AddScoped<IAccount, Account>();
        }

    }
}
