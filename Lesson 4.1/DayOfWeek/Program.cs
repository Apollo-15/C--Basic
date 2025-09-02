using System;

public class Program
{
    public static void Main(string[] args)
    {

        bool isRunning = true;

        while (isRunning)
        {
            System.Console.Write("Enter a number (1-7) to get the corresponding day of the week (enter 0 to exit the program): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "0":
                    isRunning = false;
                    System.Console.WriteLine("Exiting the program...");
                    break;

                case "1":
                    System.Console.WriteLine("Monday");
                    break;

                case "2":
                    System.Console.WriteLine("Tuesday");
                    break;

                case "3":
                    System.Console.WriteLine("Wednesday");
                    break;

                case "4":
                    System.Console.WriteLine("Thursday");
                    break;

                case "5":
                    System.Console.WriteLine("Friday");
                    break;

                case "6":
                    System.Console.WriteLine("Saturday");
                    break;

                case "7":
                    System.Console.WriteLine("Sunday");
                    break;
                default:
                    System.Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }
}