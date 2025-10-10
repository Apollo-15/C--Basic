using System;

namespace BankAccount
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Account heikkisAccount = new Account("Heikki's account", 100.00);
            Account heikkisSwissAccount = new Account("Heikki's account in Switzerland", 1000000.00);


            heikkisAccount.Withdrawal(20);
            System.Console.WriteLine("The balance of Heikki's account is now: " + heikkisAccount.Balance);
            heikkisSwissAccount.Deposit(200);
            System.Console.WriteLine("The balance of Heikki's other account is now: " + heikkisSwissAccount.Balance);
        }
    }
}