using Bank.Model.Common.Interfaces;
using Bank.Model.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.TeamFoundation.Common.Internal.NativeMethods;

namespace Bank.Model.Common.Implementations
{
    public class Banks : IBank
    {
        private List<AccountModel> accounts;
        private IDisplayUI _UI;
        private IPrinter _Print;
        private IBank _bank; // null
        private IValidateInput _Validate;
        private IAccount _account;

        public Banks(IPrinter printer, IValidateInput validateInput, IBank bank, IDisplayUI displayUI, IAccount account)
        {
            accounts = new List<AccountModel>();
            _Print = printer;
            _Validate = validateInput;
            _account = account;
            _UI = displayUI;

        }

        public Banks()
        {
        }

        //public Banks()
        //{
        //}

        public List<AccountModel> GetAccounts()
        {
            return accounts;
        }

        public void AddAccount(AccountModel account)
        {
            accounts.Add(account);
        }

        public void Start()
        {

            int choice;
            do
            {
                _UI.Menu();

                choice = _Validate.GetChoice(3);

                switch (choice)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        Login();
                        break;
                    case 3:
                        _UI.ExitMessages();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            } while (choice != 3);
        }
        public void CreateAccount()
        {
            //Console.Clear();
            Console.WriteLine("CREATE ACCOUNT\n");

            string fullName = _Validate.GetFullName();

            string password = _Validate.GetPassword();

            string email = _Validate.GetEmail();

            // Generate a random account number
            Random random = new Random();
            string accountNumber = random.Next(1000000000, 2000000000).ToString();

            _UI.AccountType();
            int choice = _Validate.GetChoice(2);
            string accountType = "";
            switch (choice)
            {
                case 1:
                    accountType = "Savings";
                    break;
                case 2:
                    accountType = "Current";
                    break;

            }

            decimal balance = _Validate.GetAmount("Enter your initial deposit: ");

            AccountModel account = new AccountModel
            {
                OwnerFullName = fullName,
                AccountNumber = accountNumber,
                AccountType = accountType,
                Balance = balance,
                Password = password,
                Email = email,
            };

            AddAccount(account);

            Console.WriteLine("Account created successfully!");
            // Add the transfer transaction to the sender's transaction history
            account.Transactions.Add(new TransactionModel
            {
                Date = DateTime.Now,
                Description = $"Initial Deposit",
                Amount = balance,
                Balance = account.Balance
            });


            // Display the created account details
            _Print.AccountDetails(account);
        }



        public void Login()
        {
            Console.Clear();
            Console.WriteLine("LOGIN\n");

            string accountNumber = _Validate.GetAccountNumber();

            string password = _Validate.GetPassword();

            // Find the account by account number and password
            AccountModel account = GetAccounts().Find(a => a.AccountNumber == accountNumber && a.Password == password);

            if (account != null)
            {
                Console.WriteLine($"Welcome, {account.OwnerFullName}!");

                int choice;
                do
                {
                    _UI.UserMenu();

                    choice = _Validate.GetChoice(7);

                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            _account.Deposit(account);
                            break;
                        case 2:
                            Console.Clear();
                            _account.Withdraw(account);
                            break;
                        case 3:
                            Console.Clear();
                            _account.Transfer(_bank, account);
                            break;
                        case 4:
                            Console.Clear();
                            _Print.Statement(account);
                            break;
                        case 5:
                            Console.Clear();
                            _Print.Balance(account);
                            break;
                        case 6:
                            Console.Clear();
                            CreateAccount();
                            break;
                        case 7:
                            Console.WriteLine("Exiting...");
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            Console.Clear();
                            break;
                    }

                    Console.WriteLine();
                } while (choice != 7);
            }
            else
            {
                Console.WriteLine("Invalid account number or password. Please try again.");
                Console.WriteLine("Press any key to return to Main Menu");
                Console.ReadKey();
                Console.Clear();
            }
        }

    }
}
