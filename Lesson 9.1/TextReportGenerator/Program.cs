using System;
using System.Text;
namespace TextReportGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StringBuilder events = new StringBuilder();
            ReadEventsFromUser(events);
            BuildReport(events);
        }

        public static void ReadEventsFromUser(StringBuilder events)
        {
            System.Console.WriteLine("Enter events (type 'exit' to finish input):");
            while (true)
            {
                string userInput = System.Console.ReadLine();
                if (userInput.ToLower() == "exit")
                {
                    break;
                }
                events.AppendLine(userInput);
            }
        }

        public static void BuildReport(StringBuilder events)
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("=======Text=Report=======");
            report.AppendLine($"Date: {DateTime.Now}");
            report.AppendLine("Events:");
            report.AppendLine(events.ToString());
            report.AppendLine("=========================");
            System.Console.WriteLine(report.ToString());
        }
    }
}