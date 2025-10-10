using System;

namespace BankAccount
{
    public class Account
    {
        private string name;
        private decimal balance;

        public Account(string name, decimal userBalance)
        {
            this.name = name;
            this.balance = userBalance;
        }

        public string Name
        {
            get { return name; }
        }
        public decimal Balance
        {
            get { return balance; }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                System.Console.WriteLine("Deposit amount must be positive!");
                return;
            }
            balance += amount;
        }

        public void Withdrawal(decimal amount)
        {
            if (amount <= 0)
            {
                System.Console.WriteLine("Withdrawal amount must be positive!");
                return;
            }

            if (amount <= balance)
            {
                balance -= amount;
            }
            else
            {
                System.Console.WriteLine("Not enough money!");
            }
        }
    }
}