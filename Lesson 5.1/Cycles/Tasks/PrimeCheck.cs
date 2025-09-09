namespace Cycles.Tasks
{
    public class PrimeCheck
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

            bool isPrime = true;

            for (int i = 2; i*i < number; i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            System.Console.WriteLine(isPrime ? $"{number} is a prime number." : $"{number} is not a prime number.");
        }
    }
}