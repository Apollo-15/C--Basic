using System.Globalization;

namespace Cycles.Tasks
{
    public class DailyWageCalculator
    {
        public static void Run()
        {
            int hoursWorked;
            decimal hourlyWage;

            while (true)
            {
                System.Console.Write("Enter the number of hours worked (enter 0 to exit the program): ");
                if (!int.TryParse(System.Console.ReadLine(), out hoursWorked) || hoursWorked < 0)
                {
                    System.Console.WriteLine("Invalid input. Please enter a non-negative integer.");
                    return;
                }

                if (hoursWorked == 0) return; else if (hoursWorked > 0) break; else System.Console.WriteLine("Please enter positive numbers.");
            }

            hourlyWage = 0;

            System.Console.Write("Enter the hourly wage: ");
            string input = System.Console.ReadLine()?.Replace(',', '.');

            if (!decimal.TryParse(input, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out hourlyWage) || hourlyWage < 0)
            {
                System.Console.WriteLine("Invalid input. Please enter a non-negative number.");
                return;
            }

            decimal dailyWage = hoursWorked * hourlyWage;
            System.Console.WriteLine($"The daily wage is: {dailyWage:F2}");
        }
    }
}