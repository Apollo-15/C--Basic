using System;
namespace NameValidator;
public class Program
{
    public static void Main(string[] args)
    {
        System.Console.Write("Enter full name (Name and Surname): ");
        string fullName = System.Console.ReadLine();

        string[] nameParts = fullName.Split(' ');
        if (nameParts.Length != 2)
        {
            System.Console.WriteLine("Please enter both name and surname.");
            return;
        }
        string name = nameParts[0];
        string surname = nameParts[1];

        if (char.ToLower(name[0]) == char.ToLower(surname[0]))
        {
            System.Console.WriteLine("Surname start with the same letter as Name.");
        }
        else
        {
            System.Console.WriteLine("Surname does not start with the same letter as Name.");
        }
    }
}