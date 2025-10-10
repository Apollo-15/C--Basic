using System;
using System.Collections.Generic;

namespace ListsOfReferences
{
    public class Program
    {
        private static List<string> tasks = new List<string>();

        public static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                System.Console.WriteLine("Choose an action: 1-Add, 2-Show, 3-Mark Done, 4-Delete, 5-Exit");
                string userInptu = System.Console.ReadLine() ?? string.Empty;

                switch (userInptu)
                {
                    case "1":
                        System.Console.Write("Enter task: ");
                        string taskInput = System.Console.ReadLine() ?? string.Empty;
                        AddTask(taskInput);
                        break;

                    case "2":
                        ShowTasks();
                        break;

                    case "3":
                        System.Console.Write("Task number to mrak as done: ");
                        if (int.TryParse(System.Console.ReadLine() ?? string.Empty, out int doneNumbre))
                        {
                            MarkTaskDone(doneNumbre);
                        }
                        else
                        {
                            System.Console.WriteLine("Invalid number input.");
                        }
                        break;

                    case "4":
                        System.Console.Write("Task number to delete: ");
                        if (int.TryParse(System.Console.ReadLine() ?? string.Empty, out int deleteNumber))
                        {
                            DeleteTask(deleteNumber);
                        }
                        else
                        {
                            System.Console.WriteLine("Invalid number input.");
                        }
                        break;

                    case "5":
                        System.Console.WriteLine("Exiting the program...");
                        isRunning = false;
                        break;

                    default:
                        System.Console.WriteLine("Invalid choice. Please input your choice from 1 to 5.");
                        break;
                }
            }
        }

        public static void AddTask(string task)
        {
            tasks.Add(task);
            System.Console.WriteLine("Task added!");
        }

        public static void ShowTasks()
        {
            if (tasks.Count == 0)
            {
                System.Console.WriteLine("List of tasks is empty.");
                return;
            }
            for (int i = 0; i < tasks.Count; i++)
            {
                System.Console.WriteLine($"{i + 1}. {tasks[i]}");
            }
        }

        public static void MarkTaskDone(int taskNumber)
        {
            if (taskNumber <= 0 || taskNumber > tasks.Count)
            {
                System.Console.WriteLine("Incorrect task number.");
                return;
            }

            tasks[taskNumber - 1] = "DONE | " + tasks[taskNumber - 1];
            System.Console.WriteLine("Task marked as done.");
        }

        public static void DeleteTask(int taskNumber)
        {
            if (taskNumber <= 0 || taskNumber > tasks.Count)
            {
                System.Console.WriteLine("Incorrect task number.");
                return;
            }

            tasks.RemoveAt(taskNumber - 1);
            System.Console.WriteLine("Task deleted.");
        }

        public static void LoadTask()
        {
            if (tasks.Count == 0)
            {
                System.Console.WriteLine("Task list is empty.");
            }
            else
            {
                ShowTasks();
            }
        }
    }
}
