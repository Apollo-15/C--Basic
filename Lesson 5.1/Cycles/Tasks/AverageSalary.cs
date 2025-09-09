using System.Globalization;

namespace Cycles.Tasks
{
    public class AverageSalary
    {
        public static void Run()
        {
            int numberOfEmployees;

            while (true)
            {
                System.Console.Write("Enter the number of employees: ");
                if (int.TryParse(System.Console.ReadLine(), out numberOfEmployees) && numberOfEmployees > 0)
                    break;
                else
                    System.Console.WriteLine("Invalid input. Please enter a positive integer.");
            }

            decimal totalSalary = 0;

            for (int i = 1; i <= numberOfEmployees; i++)
            {
                System.Console.Write($"Enter the salary for employee #{i}: ");
                string input = System.Console.ReadLine()?.Replace(',', '.');

                if (!decimal.TryParse(input, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal salary) || salary < 0)
                {
                    System.Console.WriteLine("Invalid input. Please enter a non-negative number.");
                    i--;
                    continue;
                }
                totalSalary += salary;
            }

            decimal averageSalary = totalSalary / numberOfEmployees;
            System.Console.WriteLine($"The average salary is: {averageSalary:F2}");
        }
    }
}