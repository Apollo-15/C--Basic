using Cycles.Tasks;
class Program
{   
    public static void Main(string[] args)
    {
        while (true)
        {
            System.Console.WriteLine("\nChoose a task: ");
            System.Console.WriteLine("1 - Average salary");
            System.Console.WriteLine("2 - Star graph");
            System.Console.WriteLine("3 - Prime numbers generator");
            System.Console.WriteLine("4 - Password validator");
            System.Console.WriteLine("5 - Fibonacci sequence");
            System.Console.WriteLine("6 - Daily wage calculator");
            System.Console.WriteLine("7 - Multiplication table");
            System.Console.WriteLine("8 - Prime check");
            System.Console.WriteLine("0 - Exit");

            string choice = System.Console.ReadLine();

            switch (choice)
            {
                case "1": AverageSalary.Run(); break;
                case "2": StarGraph.Run(); break;
                case "3": PrimeNumbersGenerator.Run(); break;
                case "4": PasswordValidator.Run(); break;
                case "5": FibonacciSequence.Run(); break;
                case "6": DailyWageCalculator.Run(); break;
                case "7": MultiplicationTable.Run(); break;
                case "8": PrimeCheck.Run(); break;
                case "0": System.Console.WriteLine("Exiting the program..."); return;
                default: System.Console.WriteLine("Invalid choice. Please try again."); break;
            }

        }
    }
}