using Bank.Model.User;
using System;

namespace Bank.Model
{

    public class Program
    {
        public static void Main()
        {
            DisplayUI.AppMenu();
            Bank bank = new Bank();

            int choice;
            do
            {
                DisplayUI.DiplayMenu();

                choice = ConsoleUserInput.GetChoice(3);

                switch (choice)
                {
                    case 1:
                        bank.CreateAccount();
                        break;
                    case 2:
                        bank.Login();
                        break;
                    case 3:
                        DisplayUI.ExitMessage();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            } while (choice != 3);
        }

    }
}
