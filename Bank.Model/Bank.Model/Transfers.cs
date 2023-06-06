using Bank.Model.Common;
using Bank.Model.User;
using System;

namespace Bank.Model
{
    public static class Transfers
    {
        public static void Transfer(this Account senderAccount, Bank bank)
        {
            Console.Clear();
            Console.WriteLine("TRANSFER\n");

            Console.WriteLine("Recipient's: ");
            string recipientAccountNumber = ConsoleUserInput.GetAccountNumber();

            Account recipientAccount = bank.GetAccounts().Find(a => a.AccountNumber == recipientAccountNumber);

            if (recipientAccount == null)
            {
                Console.WriteLine("Recipient account not found.");
            }
            else
            {
                decimal amount = ConsoleUserInput.GetAmount("Enter the transfer amount: ");

                if (amount > senderAccount.Balance)
                {
                    Console.WriteLine("Insufficient balance.");
                }
                else
                {
                    senderAccount.Balance -= amount;
                    recipientAccount.Balance += amount;

                    // Add the transfer transaction to the sender's transaction history
                    senderAccount.Transactions.Add(new Transaction
                    {
                        Date = DateTime.Now,
                        Description = $"Transfer to Account {recipientAccountNumber}",
                        Amount = amount,
                        Balance = senderAccount.Balance
                    });

                    // Add the transfer transaction to the recipient's transaction history
                    recipientAccount.Transactions.Add(new Transaction
                    {
                        Date = DateTime.Now,
                        Description = $"Transfer from Account {senderAccount.AccountNumber}",
                        Amount = amount,
                        Balance = recipientAccount.Balance
                    });

                    Console.WriteLine("Transfer successful!");
                }
            }
        }

    }
}
