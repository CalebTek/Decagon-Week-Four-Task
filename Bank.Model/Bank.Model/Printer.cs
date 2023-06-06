using Bank.Model.Common;
using System;
using System.Globalization;

namespace Bank.Model
{
    public static class Printer
    {

        public static void PrintStatement(this Account account)
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"ACCOUNT STATEMENT ON ACCOUNT NO {account.AccountNumber}\n");
            Console.WriteLine("|---------------------|-----------------------------------------------|--------------------------|---------------------|");
            Console.WriteLine("| DATE                | DESCRIPTION                                   | AMOUNT                   | BALANCE             |");
            Console.WriteLine("|---------------------|-----------------------------------------------|--------------------------|---------------------|");

            foreach (Transaction transaction in account.Transactions)
            {
                Console.WriteLine($"| {transaction.Date, -10} | {transaction.Description,-45} | {transaction.Amount.ToString("C", new CultureInfo("ha-Latn-NG")), -24} | {transaction.Balance.ToString("C", new CultureInfo("ha-Latn-NG")), -19} |");
            }

            Console.WriteLine("|----------------------------------------------------------------------------------------------------------------------|");
            Console.ResetColor();
        }

        public static void DisplayBalance(this Account account)
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"ACCOUNT DETAILS\n");
            Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
            Console.WriteLine("| FULL NAME         | ACCOUNT NUMBER                | ACCOUNT TYPE             | AMOUNT BAL          |");
            Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
            Console.WriteLine($"| {account.OwnerFullName,-17} | {account.AccountNumber,-29} | {account.AccountType,-24} | {account.Balance.ToString("C", new CultureInfo("ha-Latn-NG")),-19} |");
            Console.WriteLine("|----------------------------------------------------------------------------------------------------|");
            Console.ResetColor();
        }

        public static void PrintAccountDetails(this Account account)
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"ACCOUNT DETAILS\n");
            Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
            Console.WriteLine("| FULL NAME         | ACCOUNT NUMBER                | ACCOUNT TYPE             | AMOUNT BAL          |");
            Console.WriteLine("|-------------------|-------------------------------|--------------------------|---------------------|");
            Console.WriteLine($"| {account.OwnerFullName,-17} | {account.AccountNumber,-29} | {account.AccountType,-24} | {account.Balance.ToString("C", new CultureInfo("ha-Latn-NG")),-19} |");
            Console.WriteLine("|----------------------------------------------------------------------------------------------------|");
            Console.ResetColor();
        }

    }
}
