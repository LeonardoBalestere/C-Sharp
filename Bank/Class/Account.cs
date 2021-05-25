using System;

namespace Bank
{
    public class Account
    {
        public Account(AccountType accountType, string name, double balance, double credit)
        {
            this.accountType = accountType;
            this.name = name;
            this.balance = balance;
            this.credit = credit;

        }
        private AccountType accountType { get; set; }
        private string name { get; set; }

        private double balance { get; set; }

        private double credit { get; set; }

        public Account(AccountType AccountType, double balance, double credit, string name)
        {
            this.accountType = AccountType;
            this.balance = balance;
            this.credit = credit;
            this.name = name;
        }

        public Account() { }

        public bool Withdraw(double withdrawValue)
        {
            if (this.balance - withdrawValue < (this.credit * -1))
            {
                Console.WriteLine("Insuficient balance!");
                return false;
            }
            this.balance -= withdrawValue;

            Console.WriteLine("Account current balance {0} is {1}", this.name, this.balance);

            return true;
        }

        public void Deposit(double depositValue)
        {
            this.balance += depositValue;

            Console.WriteLine("Account current balance {0} is {1}", this.name, this.balance);
        }

        public void Transfer(double transferValue, Account destinyAccount)
        {
            if (this.Withdraw(transferValue))
            {
                destinyAccount.Deposit(transferValue);
            }
        }

        public override string ToString()
        {
            return "Account type " + this.accountType + "\n"
            + "Name " + this.name + "\n"
            + "Balance " + this.balance + "\n"
            + "Credit " + this.credit + "\n";
        }
    }
}