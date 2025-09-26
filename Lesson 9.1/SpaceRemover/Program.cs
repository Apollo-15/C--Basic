using System;
namespace SpaceRemover
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Console.InputEncoding = System.Text.Encoding.Unicode;
            System.Console.OutputEncoding = System.Text.Encoding.Unicode;

            System.Console.Write("Enter a string with spaces and commas: ");
            string input = System.Console.ReadLine();

            string result = input.Replace(" ", "");
            System.Console.WriteLine($"String without spaces: {result}");

        }
    }
}