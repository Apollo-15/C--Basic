namespace ArrayOperations2;
using System;
public class Program
{
    public static void Main(string[] args)
    {
        int[] array = { 3, 5, 7, 2, 8, 6 };
        int secondLargest = SecondLargestFinder(array);
        System.Console.WriteLine("=====FIRST=TASK=====");
        System.Console.WriteLine($"Second largest element is: {secondLargest}");
    }

    public static int SecondLargestFinder(int[] array)
    {
        if (array.Length < 2)
        {
            System.Console.WriteLine("Array must contain at least two elements.");
        }

        int count = 0;
        int lastMax = int.MinValue;

        foreach (var item in array)
        {
            if (item > lastMax)
            {
                lastMax = item;
                count++;

                if (count == 2)
                {
                    return item;
                }
            }
        }

        return 0;
    }
}