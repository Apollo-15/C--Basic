namespace Cycles.Tasks
{
    public class FibonacciSequence
    {
        public static void Run()
        {
            int number;

            while (true)
            {
                System.Console.WriteLine("Enter a positive integer to generate Fibonacci sequence (or enter 0 to exit): ");
                string userInput = System.Console.ReadLine();

                if (!int.TryParse(userInput, out number))
                {
                    System.Console.WriteLine("Invalid input. Please enter a valid integer.");
                    continue;
                }

                if (number == 0)
                    return;

                if (number > 0)
                    break;
                else
                    System.Console.WriteLine("Please enter a positive integer.");
            }

            System.Console.WriteLine($"Fibonacci sequence up to {number}:");
            int a = 0, b = 1;
            while (a <= number)
            {
                System.Console.Write(a + " ");
                int temp = a;
                a = b;
                b = temp + b;
            }
            System.Console.WriteLine();
        }
    }
}
