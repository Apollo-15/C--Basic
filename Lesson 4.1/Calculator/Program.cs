using System;

public class Program()
{
    public static void Main(String[] args)
    {
        bool isRunning = true;
        bool isValidOperation = true;

        while (isRunning)
        {
            System.Console.Write("Enter the first integer number: ");
            int firstNumber = int.Parse(Console.ReadLine());

            System.Console.Write("Enter the second integer number: ");
            int secondNumber = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter an operation (+, -, *, /) (enter 0 to exit the program): ");
            string choice = Console.ReadLine();

            int result = 0;

            switch (choice)
            {   
                case "0":
                    isRunning = false;
                    System.Console.WriteLine("Exiting the program...");
                    break;

                case "+":
                    result = firstNumber + secondNumber;
                    break;

                case "-":
                    result = firstNumber - secondNumber;
                    break;

                case "*":
                    result = firstNumber * secondNumber;
                    break;

                case "/":
                    if (secondNumber != 0)
                    {
                        result = firstNumber / secondNumber;
                    }
                    else
                    {
                        System.Console.WriteLine("Division by zero is not allowed.");
                        isValidOperation = false;
                    }
                    break;
                default:
                    System.Console.WriteLine("Invalid operation. Please enter one of the following: +, -, *, /.");
                    isValidOperation = false;
                    break;
                    
            }
            if (isRunning)
            {  
                if (isValidOperation)
                {
                    System.Console.WriteLine($"Result: {result}");
                }
            }
        }
    }
}