using System;
using System.Collections.Generic;

namespace Bank
{
    class Program
    {
        static List<Account> accountList = new List<Account>();
        static void Main(string[] args)
        {
            string userOption = TakeUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch(userOption)
                {
                    case "1":
                        ListAccounts();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = TakeUserOption();
            }
            Console.WriteLine("Thank you for using our Services.");
            Console.ReadLine();
        }

        private static void Deposit()
        {
             Console.Write("Enter account number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter the withdraw value: ");
            double withdrawValue = double.Parse(Console.ReadLine());

            accountList[accountNumber].Deposit(withdrawValue);
        }

        private static void Withdraw()
        {
            Console.Write("Enter account number: ");
            int accountNumber = int.Parse(Console.ReadLine());

            Console.Write("Enter the withdraw value: ");
            double withdrawValue = double.Parse(Console.ReadLine());

            accountList[accountNumber].Withdraw(withdrawValue);
        }

        private static void Transfer()
        {
            Console.Write("Enter origin account number: ");
            int accountNumberOrigin = int.Parse(Console.ReadLine());

            Console.Write("Enter destiny account number: ");
            int accountNumberDestiny = int.Parse(Console.ReadLine());

            Console.Write("Enter the transfer value: ");
            double transferValue = double.Parse(Console.ReadLine());

            accountList[accountNumberOrigin].Transfer(transferValue: transferValue,destinyAccount: accountList[accountNumberDestiny]);
        }

        private static void ListAccounts()
        {
            throw new NotImplementedException();
        }

        private static void InsertAccount()
        {
            Console.WriteLine("Insert new account:");

            Console.Write("Enter 1 for fisical person and 2 for legal person: ");
            int initialAccountType = int.Parse(Console.ReadLine());

            Console.Write("Enter user's name: ");
            string initialName = Console.ReadLine();

            Console.Write("Enter initial balance: ");
            double initialBalance = double.Parse(Console.ReadLine());

            Console.Write("Enter the Credit: ");
            double initialCredit = double.Parse(Console.ReadLine());

            Account newAccount = new Account(accountType: (AccountType)initialAccountType,
                                            balance: initialBalance,
                                            credit: initialCredit,
                                            name: initialName);

            accountList.Add(newAccount);
        }

        private static string TakeUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("How can I help you?");
            Console.WriteLine("Chose the desire option:");

            Console.WriteLine("1 - List accounts");
            Console.WriteLine("2 - Insert new account");
            Console.WriteLine("3 - Transfer");
            Console.WriteLine("4 - Withdraw");
            Console.WriteLine("5 - Deposit");
            Console.WriteLine("C - Clear the screen");
            Console.WriteLine("X - Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}