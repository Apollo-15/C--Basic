using System;
using FileIOCopyApp.Services;

namespace FileIoCopyApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            System.Console.Write("Enter path to source file: ");
            string sourcePath = System.Console.ReadLine()!;

            System.Console.WriteLine("Enter path to destination file: ");
            string destinationFile = System.Console.ReadLine()!;

            var service = new FileCopyService();
            var result = service.CopyFile(sourcePath, destinationFile);

            if (result.Success)
            {
                System.Console.ForegroundColor = System.ConsoleColor.Green;
                System.Console.WriteLine(result.Message);
            }
            else
            {
                System.Console.ForegroundColor = System.ConsoleColor.Red;
                System.Console.WriteLine(result.Message);
            }
            
            System.Console.ResetColor();
        }
    }
}