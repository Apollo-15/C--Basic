using System;
using System.Reflection.PortableExecutable;

namespace DivideByZero
{
    public class Program()
    {
        public static void Main(string[] args)
        {
            try
            {
                System.Console.Write("Enter first number: ");
                if (!double.TryParse(System.Console.ReadLine(), out double firstNumber))
                {
                    throw new FormatException("Invalid number entered!");
                }
                System.Console.Write("Enter the second number: ");
                if (!double.TryParse(System.Console.ReadLine(), out double secondNumber))
                {
                    throw new FormatException("Invalid number entered!");
                }
                if (secondNumber == 0)
                {
                    throw new DivideByZeroException("Cannot divide by zero!");
                }

                double result = firstNumber / secondNumber;
                System.Console.WriteLine($"Result: {result}");
            }
            catch (FormatException ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Unexpected error: {ex.Message}");
            }

        }
    }
}