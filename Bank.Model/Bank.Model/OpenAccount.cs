using Bank.Model.Common;
using Bank.Model.User;
using System;

namespace Bank.Model
{
    public static class OpenAccount
    {
        public static void CreateAccount(this Bank bank)
        {
            Console.Clear();
            Console.WriteLine("CREATE ACCOUNT\n");

            string fullName = ConsoleUserInput.GetFullName();

            string password = ConsoleUserInput.GetPassword();

            string email = ConsoleUserInput.GetEmail();

            // Generate a random account number
            Random random = new Random();
            string accountNumber = random.Next(1000000000, 2000000000).ToString();

            DisplayUI.AccountType();
            int choice = ConsoleUserInput.GetChoice(2);
            string accountType = "";
            switch(choice)
            {
                case 1:
                    accountType = "Savings";
                    break;
                case 2:
                    accountType = "Current";
                    break;

            }

            decimal balance = ConsoleUserInput.GetAmount("Enter your initial deposit: ");

            Account account = new Account
            {
                OwnerFullName = fullName,
                AccountNumber = accountNumber,
                AccountType = accountType,
                Balance = balance,
                Password = password,
                Email = email,
            };

            bank.AddAccount(account);

            Console.WriteLine("Account created successfully!");
            // Add the transfer transaction to the sender's transaction history
            account.Transactions.Add(new Transaction
            {
                Date = DateTime.Now,
                Description = $"Initial Deposit",
                Amount = balance,
                Balance = account.Balance
            });


            // Display the created account details
            account.PrintAccountDetails();
        }
    }
}
