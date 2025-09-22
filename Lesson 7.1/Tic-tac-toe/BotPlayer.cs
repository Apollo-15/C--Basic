namespace Tic_tac_toe
{
    public class BotPlayer(string name, char symbol) : IPlayer
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

    public int ChooseCell()
        {
            int botNum = Symbol == 'X' ? 1 : 2;
            int humanNum = Symbol == 'X' ? 2 : 1;

            foreach (var pattern in winPatterns)
            {
                int botCount = 0, emptyCount = 0, emptyCell = -1;
                foreach (var index in pattern)
                {
                    int cellIndex = index + 1;
                    if (Board.GetCell(cellIndex) == botNum)
                        botCount++;
                    else if (Board.GetCell(cellIndex) == 0)
                    {
                        emptyCount++;
                        emptyCell = cellIndex;
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
                    int cellIndex = index + 1;
                    if (Board.GetCell(cellIndex) == humanNum)
                        humanCount++;
                    else if (Board.GetCell(cellIndex) == 0)
                    {
                        emptyCount++;
                        emptyCell = cellIndex;
                    }
                }
                if (humanCount == 2 && emptyCount == 1)
                    return emptyCell;
            }

            int[] priority = { 4, 0, 2, 6, 8, 1, 3, 5, 7 };
            foreach (var i in priority)
            {
                int cellIndex = i + 1;
                if (Board.IsCellEmpty(cellIndex))
                    return cellIndex;
            }

            var random = new Random();
            int cell;
            do
            {
                cell = random.Next(1, 10);
            } while (!Board.IsCellEmpty(cell));
            return cell;
        }

        public void MakeMove()
        {
            int cell = ChooseCell();
            int playerNumber = Symbol == 'X' ? 1 : 2;
            Board.PlaceMark(cell, playerNumber);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{Name} placed (");
            Console.Write(Symbol);
            Console.Write($") in cell {cell}");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}