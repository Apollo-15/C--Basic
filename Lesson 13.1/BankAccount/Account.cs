using System;

namespace BankAccount
{
    public class Account
    {
        private string name;
        private double balance;

        public Account(string name, double userBalance)
        {
            this.name = name;
            this.balance = userBalance;
        }

        public string Name
        {
            get { return name; }
        }
        public double Balance
        {
            get { return balance; }
        }

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public void Withdrawal(double amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
            }
            else
            {
                System.Console.WriteLine("Not enogh money!");
            }
        }
    }
}