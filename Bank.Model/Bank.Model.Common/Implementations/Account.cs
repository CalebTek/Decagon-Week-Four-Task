using Bank.Model.Common.Interfaces;
using Bank.Model.Common.Models;
using Microsoft.VisualStudio.Services.Account;
using System;
using System.Security.Principal;

namespace Bank.Model.Common.Implementations
{
    public class Account : IAccount
    {
        private IValidateInput _Validate;

        public Account()
        {
        }

        public Account(IValidateInput validateInput)
        {
            _Validate = validateInput;
        }
        public void Deposit(AccountModel account)
        {
            //Console.Clear();
            Console.WriteLine("DEPOSIT\n");

            decimal amount = _Validate.GetAmount("Enter the deposit amount: ");

            account.Balance += amount;

            // Add the deposit transaction to the account's transaction history
            account.Transactions.Add(new TransactionModel
            {
                Date = DateTime.Now,
                Description = "Deposit",
                Amount = amount,
                Balance = account.Balance
            });

            Console.WriteLine("Deposit successful!");
        }

        public void Transfer(IBank bank, AccountModel senderAccount)
        {
            //Console.Clear();
            Console.WriteLine("TRANSFER\n");

            Console.WriteLine("Recipient's: ");
            string recipientAccountNumber = _Validate.GetAccountNumber();

            AccountModel recipientAccount = bank.GetAccounts().Find(a => a.AccountNumber == recipientAccountNumber);

            if (recipientAccount == null)
            {
                Console.WriteLine("Recipient account not found.");
            }
            else
            {
                decimal amount = _Validate.GetAmount("Enter the transfer amount: ");

                if (amount > senderAccount.Balance)
                {
                    Console.WriteLine("Insufficient balance.");
                }
                else
                {
                    senderAccount.Balance -= amount;
                    recipientAccount.Balance += amount;

                    // Add the transfer transaction to the sender's transaction history
                    senderAccount.Transactions.Add(new TransactionModel
                    {
                        Date = DateTime.Now,
                        Description = $"Transfer to Account {recipientAccountNumber}",
                        Amount = amount,
                        Balance = senderAccount.Balance
                    });

                    // Add the transfer transaction to the recipient's transaction history
                    recipientAccount.Transactions.Add(new TransactionModel
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

        public void Withdraw(AccountModel account)
            {
            //Console.Clear();
            Console.WriteLine("WITHDRAW\n");

            decimal amount = _Validate.GetAmount("Enter the withdrawal amount: ");

            if (amount > account.Balance)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            {
                account.Balance -= amount;

                // Add the withdrawal transaction to the account's transaction history
                account.Transactions.Add(new TransactionModel
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