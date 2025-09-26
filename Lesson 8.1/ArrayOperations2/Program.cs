using System;
namespace ArrayOperations2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = { 3, 4, 7, 2, 8, 6, 11, 9 }; // Largest: 3<4→4<7→7<8→8<11→11 | 11, Second largest: 3<4→4<7→7<8→8<9→9 | 9
            int[,] twoDimArray = {
                { 5, 3, 7 },
                { 1, 9, 8 },
                { 4, 2, 6 }
            };
            int secondLargest = SecondLargestFinder(array);
            const int INDEX_TO_REMOVE = 3; // Example index to remove

            System.Console.WriteLine("=====FIRST=TASK=====");
            System.Console.WriteLine($"Second largest element is: {secondLargest}");
            System.Console.WriteLine("=====SECOND=TASK=====");
            TwoDimArraySorter(twoDimArray);
            System.Console.WriteLine("=====THIRD=TASK======");
            System.Console.WriteLine($"Array before removing element {indexToRemove}: [{string.Join(", ", array)}]");
            ArrayElementRemover(array, indexToRemove);
        }

        public static int SecondLargestFinder(int[] array)
        {
            if (array.Length < 2)
            {
                System.Console.WriteLine("Array must contain at least two elements.");
            }

            int firstLargest = int.MinValue;
            int secondLargest = int.MinValue;

            foreach (int number in array)
            {
                if (number > firstLargest)
                {
                    secondLargest = firstLargest;
                    firstLargest = number;
                }
                else if (number > secondLargest && number != firstLargest)
                {
                    secondLargest = number;
                }
            }
            return secondLargest;
        }

        public static void TwoDimArraySorter(int[,] array)
        {
            int rows = array.GetLength(0);
            int columns = array.GetLength(1);

            int[] flatArray = new int[rows * columns];
            int index = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    flatArray[index++] = array[i, j];
                }
            }

            Array.Sort(flatArray);

            index = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    array[i, j] = flatArray[index++];
                }
            }

            System.Console.WriteLine("Sorted 2d array:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    System.Console.Write(array[i, j] + " ");
                }
                System.Console.WriteLine();
            }
        }

        public static int ArrayElementRemover(int[] array, int indexToRemove)
        {
            if (indexToRemove < 0 || indexToRemove >= array.Length)
            {
                System.Console.WriteLine("Index out of bounds.");
                return array.Length;
            }

            int[] newArray = new int[array.Length - 1];
            int newIndex = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (i != indexToRemove)
                {
                    newArray[newIndex++] = array[i];
                }

            }

            array = newArray;
            System.Console.WriteLine($"Array after removing element {indexToRemove}: [{string.Join(", ", array)}]");
            return array.Length;
        }
    }  
}