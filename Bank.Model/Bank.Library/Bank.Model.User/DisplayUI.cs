using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model.User
{
    public static class DisplayUI
    {
        public static void DiplayMenu()
        {
            Console.WriteLine(AppMessages.startMessage);
        }

        public static void DiplayUserMenu() 
        {
            Console.WriteLine(AppMessages.userMessage);
        }

        public static void AccountType()
        {
            Console.WriteLine(AppMessages.AccountMessage);
        }

        public static void AppMenu()
        {
            Console.WriteLine(AppMessages.AppMessage);
        }

        public static void ExitMessage()
        {
            Console.WriteLine(AppMessages.ExitMessage);
        }
    }
}
