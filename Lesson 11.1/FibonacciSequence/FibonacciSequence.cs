using System;

namespace FibonacciSequence
{
    public static class FibonacciSequence
    {
        public static int GetFibonacci(int n)
        {
            if (n <= 0) return 0;
            if (n == 2) return 1;
            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }

        public static void Run()
        {
            int number;

            while (true)
            {
                System.Console.WriteLine("Enter the position of the Fibonacci number (or 0 to exit): ");
                string userInput = System.Console.ReadLine();

                if (!int.TryParse(userInput, out number))
                {
                    System.Console.WriteLine("Invalid input. Please enter a valid integer.");
                    continue;
                }

                if (number == 0)
                    return;

                if (number > 0)
                {
                    int result = GetFibonacci(number);
                    System.Console.WriteLine($"Fibonacci number at position {number} is {result}");
                }
                else
                {
                    System.Console.WriteLine("Please enter a positive integer.");
                }
            }
        }
    }
}
