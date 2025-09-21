namespace Tic_tac_toe
{
    public class BotPlayer(string name, char symbol) : Player
    {
        public char Symbol { get; private set; } = symbol;
        public string Name { get; private set; } = name;

        private static readonly int[][] winPatterns = new int[][]
        {
            new[] {0, 1, 2},
            new[] {3, 4, 5},
            new[] {6, 7, 8},
            new[] {0, 3, 6},
            new[] {1, 4, 7},
            new[] {2, 5, 8},
            new[] {0, 4, 8},
            new[] {2, 4, 6}
        };

        public int ChooseCell(Board board)
        {
            int botNum = Symbol == 'X' ? 1 : 2;
            int humanNum = Symbol == 'X' ? 2 : 1;

            foreach (var pattern in winPatterns)
            {
                int botCount = 0, emptyCount = 0, emptyCell = -1;
                foreach (var index in pattern)
                {
                    if (GetCell(board, index) == botNum)
                        botCount++;
                    else if (GetCell(board, index) == 0)
                    {
                        emptyCount++;
                        emptyCell = index;
                    }
                }
                if (botCount == 2 && emptyCount == 1)
                    return emptyCell;
            }

            foreach (var pattern in winPatterns)
            {
                int humanCount = 0, emptyCount = 0, emptyCell = -1;
                foreach (var index in pattern)
                {
                    if (GetCell(board, index) == humanNum)
                        humanCount++;
                    else if (GetCell(board, index) == 0)
                    {
                        emptyCount++;
                        emptyCell = index;
                    }
                }
                if (humanCount == 2 && emptyCount == 1)
                    return emptyCell;
            }

            int[] priority = { 4, 0, 2, 6, 8, 1, 3, 5, 7 };
            foreach (var i in priority)
            {
                if (board.IsCellEmpty(i))
                    return i;
            }

            var random = new Random();
            int cell;
            do
            {
                cell = random.Next(0, 9);
            } while (!board.IsCellEmpty(cell));
            return cell;
        }

        private int GetCell(Board board, int index)
        {
            int x = index / 3;
            int y = index % 3;
            return board.GetCell(index);
        }

        public void MakeMove(Board board)
        {
            int cell = ChooseCell(board);
            int playerNumber = Symbol == 'X' ? 1 : 2;
            board.PlaceMark(cell, playerNumber);
            System.Console.WriteLine($"{Name} placed ({Symbol}) in cell {cell + 1}");

        }
    }
}