using System;

namespace HandlingInvalidNumberFormat
{
    public class Program()
    {
        public static void Main(string[] args)
        {
            try
            {
                System.Console.Write("Enter a number:");
                string userInput = System.Console.ReadLine();

                if (!double.TryParse(userInput, out double number))
                {
                    throw new FormatException("Invalid number entered");
                }
                System.Console.WriteLine($"You entered: {number}");
            }
            catch (FormatException ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}