using Bank.Model.Common.Interfaces;
using System;
using System.Text.RegularExpressions;


namespace Bank.Model.Common.Implementations
{
    public  class ConsoleUserInput : IValidateInput
    {
        public int GetChoice(int max)
        {
            int choice = 0;
            bool isValidChoice = false;

            while (!isValidChoice)
            {
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer choice.");
                    Console.Beep();
                }
                else if (choice < 1 || choice > max)
                {
                    Console.WriteLine($"Invalid choice. Please enter a number between 1 and {max}.");
                    Console.Beep();
                }
                else
                {
                    isValidChoice = true;
                }
            }

            return choice;
        }

        public int GetChoice(int min, int max)
        {
            int choice = 0;
            bool isValidChoice = false;

            while (!isValidChoice)
            {
                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalid input.\nPlease enter a valid integer choice.");
                }
                else if (choice < min || choice > max)
                {
                    Console.WriteLine($"Invalid choice.\nPlease enter a number between {min} and {max}.");
                }
                else
                {
                    isValidChoice = true;
                }
            }

            return choice;
        }

        public string GetAccountNumber()
        {
            string accountNumber = "";

            while (string.IsNullOrEmpty(accountNumber) || accountNumber.Length != 10)
            {
                Console.Write("Enter account number\n(must be 10 characters): ");
                accountNumber = Console.ReadLine();

                if (string.IsNullOrEmpty(accountNumber))
                {
                    Console.WriteLine("Invalid input.\nPlease enter a valid account number.");
                }
                else if (accountNumber.Length != 10)
                {
                    Console.WriteLine("Invalid account number length.\nIt must be exactly 10 characters.");
                }
            }

            return accountNumber;
        }

        public string GetPassword()
        {
            string password = "";

            while (string.IsNullOrEmpty(password) || !IsValidPassword(password))
            {
                Console.Write("Enter your password\n(must contain at least 8 characters,\nstart with an uppercase letter, and\ninclude both a number and a special character): ");
                password = Console.ReadLine();

                if (string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Invalid input.\nPlease enter a valid password.");
                }
                else if (!IsValidPassword(password))
                {
                    Console.WriteLine("Invalid password.\nIt must contain at least 8 characters,\nstart with an uppercase letter, and \ninclude both a number and a special character.");
                }
            }

            return password;
        }

        public bool IsValidPassword(string password)
        {
            // Password validation regular expression pattern
            string pattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";

            return Regex.IsMatch(password, pattern);
        }
        public  string GetFullName()
        {
            string fullName = "";

            while (string.IsNullOrEmpty(fullName) || !IsValidFullName(fullName))
            {
                Console.Write("Enter your full name: ");
                fullName = Console.ReadLine();

                if (string.IsNullOrEmpty(fullName))
                {
                    Console.WriteLine("Invalid input.\nPlease enter a valid full name.");
                }
                else if (!IsValidFullName(fullName))
                {
                    Console.WriteLine("Invalid full name.\nIt must contain at least two words.");
                }
            }

            return fullName;
        }

        public  bool IsValidFullName(string fullName)
        {
            string[] nameParts = fullName.Split(' ');

            return nameParts.Length >= 2;
        }

        public  decimal GetAmount(string prompt)
        {
            decimal number = 0;
            bool isValidNumber = false;

            while (!isValidNumber)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!decimal.TryParse(input, out number))
                {
                    Console.WriteLine("Invalid input.\nPlease enter a valid decimal number.");
                }
                else
                {
                    isValidNumber = true;
                }
            }

            return number;
        }

        public string GetEmail()
        {
            string email = "";

            while (!IsValidEmail(email))
            {
                Console.Write("Enter your email address: ");
                email = Console.ReadLine();

                if (!IsValidEmail(email))
                {
                    Console.WriteLine("Invalid email address.\nPlease enter a valid email address.");
                }
            }

            return email;
        }

        public bool IsValidEmail(string email)
        {
            // Email validation regular expression pattern
            string pattern = @"^[a-zA-Z0-9_.+-]+@(gmail\.com|yahoo\.com|outlook\.com)$";

            return Regex.IsMatch(email, pattern);
        }

    }
}
