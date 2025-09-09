namespace Cycles.Tasks
{
    public class StarGraph
    {
        public static void Run()
        {
            int rows;

            while (true)
            {
                System.Console.Write("Enter the number of rows for the star graph: ");

                if (int.TryParse(System.Console.ReadLine(), out rows) && rows > 0)
                    break;
                else
                    System.Console.WriteLine("Invalid input. Please enter a positive integer.");
            }

            for (int i = 1; i <= rows; i++)
            {
                System.Console.WriteLine(new string('*', i));
            }

        }
    }
}