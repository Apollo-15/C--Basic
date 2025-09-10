namespace Cycles.Tasks
{
    public class MultiplicationTable
    {
        public static void Run()
        {
            int number;

            while (true)
            {
                System.Console.WriteLine("Enter the integer number (enter 0 to exit the program): ");
                if (!int.TryParse(System.Console.ReadLine(), out number))
                {
                    System.Console.WriteLine("Invalid input. Please enter a valid integer.");
                    return;
                }
                if (number == 0)
                    return;

                if (number > 0)
                    break;
                else
                    System.Console.WriteLine("PInvalid input. Please enter a valid integer.");
            }

            System.Console.WriteLine($"Multiplication table for {number}:");

            for (int i = 1; i <= 10; i++)
            {
                System.Console.WriteLine($"{number} x {i} = {number * i}");
            }
        }
    }
}