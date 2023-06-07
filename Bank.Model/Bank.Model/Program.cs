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
                .AddSingleton<Banks, Banks>()
                .BuildServiceProvider()
                .GetService<Banks>()
                .Start();

            //.AddTransient<IDisplayUI, DisplayUI>()
        }

        public static void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<IPrinter, Printer>();
            services.AddTransient<IValidateInput, ConsoleUserInput>();
            services.AddTransient<IDisplayUI, DisplayUI>();
            services.AddTransient<IAccount, Account>();
        }

    }
}
