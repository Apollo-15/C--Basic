namespace Cycles.Tasks
{
    public class PrimeNumbersGenerator
    {
        public static void Run()
        {
            int number;

            while (true)
            {
                System.Console.WriteLine("Enter integer number: ");

                if (!int.TryParse(System.Console.ReadLine(), out number) || number >= 2)
                    break;
                else
                    System.Console.WriteLine("Invalid input. Please enter an integer greater than 1.");
            }

            System.Console.WriteLine($"Prime numbers up to {number}:");
            for (int i = 2; i <= number; i++)
            {
                bool isPrime = true;

                for (int y = 2; y <= Math.Sqrt(i); y++)
                {
                    if (i % y == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    System.Console.Write(i + " ");
                }
            }
        }
    }
}