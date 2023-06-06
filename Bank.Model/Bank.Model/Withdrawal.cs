using Bank.Model.Common;
using Bank.Model.User;
using System;

namespace Bank.Model
{
    public static class Withdrawal
    {
        public static void Withdraw(this Account account)
        {
            Console.Clear();
            Console.WriteLine("WITHDRAW\n");

            decimal amount = ConsoleUserInput.GetAmount("Enter the withdrawal amount: ");

            if (amount > account.Balance)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            {
                account.Balance -= amount;

                // Add the withdrawal transaction to the account's transaction history
                account.Transactions.Add(new Transaction
                {
                    Date = DateTime.Now,
                    Description = "Withdrawal",
                    Amount = amount,
                    Balance = account.Balance
                });

                Console.WriteLine("Withdrawal successful!");
            }
        }

    }
}
