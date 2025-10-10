using System;

namespace BankAccount
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Account heikkisAccount = new Account("Heikki's account", 100.00m);
            Account heikkisSwissAccount = new Account("Heikki's account in Switzerland", 1000000.00m);

            heikkisAccount.Withdrawal(20m);
            Console.WriteLine($"The balance of Heikki's account is now: {heikkisAccount.Balance:F2}");

            heikkisSwissAccount.Deposit(200m);
            Console.WriteLine($"The balance of Heikki's other account is now: {heikkisSwissAccount.Balance:F2}");
        }
    }
}