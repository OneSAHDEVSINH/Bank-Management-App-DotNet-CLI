using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static Dictionary<string, BankAccount> accounts = new Dictionary<string, BankAccount>();
        static string currentAccountNumber = null;

        static void Main(string[] args)
        {
            bool continueApp = true;
            while (continueApp)
            {
                if (currentAccountNumber == null)
                {
                    DisplayMainMenu();
                }
                else
                {
                    DisplayAccountMenu();
                }

                int choice = GetValidChoice();

                switch (choice)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        LoginAccount();
                        break;
                    case 3:
                        continueApp = false;
                        break;
                    case 4:
                        DepositMoney();
                        break;
                    case 5:
                        WithdrawMoney();
                        break;
                    case 6:
                        CheckAccountBalance();
                        break;
                    case 7:
                        LogoutAccount();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Bank Account Management System");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Login to Account");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
        }

        static void DisplayAccountMenu()
        {
            Console.Clear();
            Console.WriteLine("Account Menu");
            Console.WriteLine("------------");
            Console.WriteLine("4. Deposit Money");
            Console.WriteLine("5. Withdraw Money");
            Console.WriteLine("6. Check Balance");
            Console.WriteLine("7. Logout");
            Console.Write("Enter your choice: ");
        }

        static int GetValidChoice()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (currentAccountNumber == null && (choice == 1 || choice == 2 || choice == 3))
                        return choice;
                    else if (currentAccountNumber != null && (choice == 4 || choice == 5 || choice == 6 || choice == 7))
                        return choice;
                    else
                        Console.WriteLine("Invalid choice for current context. Please try again.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }

        static void CreateAccount()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            Console.Write("Enter account holder name: ");
            string accountHolderName = Console.ReadLine();
            Console.Write("Enter initial balance (default is 0): ");
            if (decimal.TryParse(Console.ReadLine(), out decimal initialBalance))
            {
                BankAccount account = new BankAccount(accountNumber, accountHolderName, initialBalance);
                accounts[accountNumber] = account;
                Console.WriteLine("Account created successfully!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid initial balance. Please enter a valid number.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void LoginAccount()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            if (accounts.ContainsKey(accountNumber))
            {
                currentAccountNumber = accountNumber;
                Console.WriteLine("Logged in successfully!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Account not found. Please check your account number.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void DepositMoney()
        {
            Console.Write("Enter amount to deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                accounts[currentAccountNumber].Deposit(amount);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid deposit amount. Please enter a valid number.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void WithdrawMoney()
        {
            Console.Write("Enter amount to withdraw: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                accounts[currentAccountNumber].Withdraw(amount);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount. Please enter a valid number.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static void CheckAccountBalance()
        {
            accounts[currentAccountNumber].CheckBalance();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void LogoutAccount()
        {
            currentAccountNumber = null;
            Console.WriteLine("Logged out successfully!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
