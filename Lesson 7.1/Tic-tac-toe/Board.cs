namespace Tic_tac_toe
{
    public class Board
    {
        private static int[,] board = new int[3,3];

        public static void DisplayBoard()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    int cellNum = x * 3 + y + 1;
                    if (board[x, y] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        System.Console.Write($" {cellNum} ");
                    }
                    else if (board[x, y] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        System.Console.Write(" X ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        System.Console.Write(" O ");
                    }
                    Console.ResetColor();
                    if (y < 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        System.Console.Write("|");
                        Console.ResetColor();
                    }
                }
                System.Console.WriteLine();
                if (x < 2)
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    System.Console.WriteLine("---+---+---");
                    Console.ResetColor();
                }
            }
        }

        public static bool IsCellEmpty(int cell)
        {
            int x = (cell - 1) / 3;
            int y = (cell - 1) % 3;

            if (board[x, y] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void PlaceMark(int cell, int player)
        {
            int x = (cell - 1) / 3;
            int y = (cell - 1) % 3;

            board[x, y] = player;
        }

        public static int GetCell(int cell)
        {
            int x = (cell - 1) / 3;
            int y = (cell - 1) % 3;

            return board[x, y];
        }

        public static bool IsWin(int player)
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == player && board[i, 1] == player && board[i, 2] == player)
                {
                    return true;
                }
                if (board[0, i] == player && board[1, i] == player && board[2, i] == player)
                {
                    return true;
                }

            }
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            {
                return true;
            }
            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
            {
                return true;
            }

            return false;
        }

        public static bool IsDraw()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (board[x, y] == 0)
                    {
                        return false;
                    }
                }
            }

            if (!IsWin(1) && !IsWin(2))
            {
                return true;
            }

            return false;
        }

        public static void ResetBoard()
        {
            board = new int[3, 3];
        }
    }
}