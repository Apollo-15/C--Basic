using System;

class Program
{
    public enum DayOfWeek
    {
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }

    public static void Main(string[] args)
    {
        int[] numbers = new int[10];
        System.Console.WriteLine("=========First=Task=========");
        PrintEvenIndexElements(numbers);
        System.Console.WriteLine("========Second==Task========");
        CheckArraySumNonNegative(numbers);
        System.Console.WriteLine("=========Third=Task=========");
        PrintMultiplicationTable();
        System.Console.WriteLine("=========Fourth=Task=========");
        Analyze2DArray();
        System.Console.WriteLine("=========Fifth=Task=========");
        PrintDayOfWeek();
    }
    public static void PrintEvenIndexElements(int[] numbers)
    {
        Random rand = new Random();
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = rand.Next(-10, 11);
        }
        for (int i = 0; i < numbers.Length; i += 2)
        {
            System.Console.WriteLine($"Element at index {i}: {numbers[i]}");
        }
    }

    public static void CheckArraySumNonNegative(int[] numbers)
    {
        //1st variant
        // foreach (int number in numbers)
        // {
        //     sum += number;
        // }
        // if (sum >= 0)
        // {
        //     System.Console.WriteLine("The sum of the array elements is positive.");
        // }
        // else
        // {
        //     System.Console.WriteLine("The sum of the array elements is negative.");
        // }

        //2nd variant
        // int sum = numbers.Sum();
        // if (sum >= 0)
        // {
        //     System.Console.WriteLine("The sum of the array elements is positive.");
        // }
        // else
        // {
        //     System.Console.WriteLine("The sum of the array elements is negative.");
        // }

        //3rd variant
        System.Console.WriteLine(numbers.Sum() >= 0
        ? "The sum of the array elements is positive."
        : "The sum of the array elements is negative.");
    }

    public static void PrintMultiplicationTable()
    {
        int[,] table = {
            {1, 2, 3, 4, 5, 6, 7, 8, 9},
            {2, 4, 6, 8, 10, 12, 14, 16, 18},
            {3, 6, 9, 12, 15, 18, 21, 24, 27},
            {4, 8, 12, 16, 20, 24, 28, 32, 36},
            {5, 10, 15, 20, 25, 30, 35, 40, 45},
            {6, 12, 18, 24, 30, 36, 42, 48, 54},
            {7, 14, 21, 28, 35, 42, 49, 56, 63},
            {8, 16, 24, 32, 40, 48, 56, 64, 72},
            {9, 18, 27, 36, 45, 54, 63, 72, 81}
        };

        for (int i = 0; i < table.GetLength(0); i++)
        {
            for (int j = 0; j < table.GetLength(1); j++)
            {
                System.Console.Write($"{table[i, j],4}");
            }
            System.Console.WriteLine();
        }
    }

    public static void Analyze2DArray()
    {
        int[,] matrix = {
            {28, 10, 63, 47, 15},
            {32, 54, 21, 43, 12},
            {14, 75, 36, 29, 18},
            {41, 23, 67, 11, 39},
            {50, 27, 34, 72, 16}
        };

        Tuple<int, int, int> max = Tuple.Create(int.MinValue, -1, -1);
        Tuple<int, int, int> min = Tuple.Create(int.MaxValue, -1, -1);

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int value = matrix[i, j];

                if (value > max.Item1)
                {
                    max = Tuple.Create(value, i, j);
                }

                if (value < min.Item1)
                {
                    min = Tuple.Create(value, i, j);
                }
            }
        }

        System.Console.WriteLine($"Minimum: {min.Item1} at ({min.Item2},{min.Item3})");
        System.Console.WriteLine($"Maximum: {max.Item1} at ({max.Item2},{max.Item3})");
    }

    public static void PrintDayOfWeek()
    {
        System.Console.Write("Enter number of days: ");
        bool success = int.TryParse(System.Console.ReadLine(), out int days);
        
        if (!success || days < 0)
        {
            System.Console.WriteLine("Invalid input. Please enter a non-negative integer.");
            return;
        }


        DayOfWeek start = DateTime.Now.DayOfWeek switch
        {
            System.DayOfWeek.Sunday => DayOfWeek.Sunday,
            System.DayOfWeek.Monday => DayOfWeek.Monday,
            System.DayOfWeek.Tuesday => DayOfWeek.Tuesday,
            System.DayOfWeek.Wednesday => DayOfWeek.Wednesday,
            System.DayOfWeek.Thursday => DayOfWeek.Thursday,
            System.DayOfWeek.Friday => DayOfWeek.Friday,
            System.DayOfWeek.Saturday => DayOfWeek.Saturday,
            _ => throw new ArgumentOutOfRangeException()
        };

        DayOfWeek result = (DayOfWeek)(((int)start + days) % 7);
        System.Console.WriteLine($"In {days} days it will be {result}");

    }
}