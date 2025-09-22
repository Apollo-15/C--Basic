namespace Tic_tac_toe
{
    public class HumanPlayer(string name, char symbol) : IPlayer
    {
        public char Symbol { get; private set; } = symbol;
        public string Name { get; private set; } = name;


        public int ChooseCell()
        {
            int cell;
            while (true)
            {
                System.Console.Write($"{Name}, enter your move (1-9): ");
                if (int.TryParse(System.Console.ReadLine(), out cell) &&
                    cell >= 1 && cell <= 9 &&
                    Board.IsCellEmpty(cell))
                {
                    break;
                }
                System.Console.WriteLine("Invalid move. Try again.");
            }
            return cell;
        }

        public void MakeMove()
        {
            int cell = ChooseCell();
            int playerNumber = Symbol == 'X' ? 1 : 2;
            Board.PlaceMark(cell, playerNumber);
            ConsoleColor color = playerNumber == 1 ? ConsoleColor.Green : ConsoleColor.Blue;
            Console.ForegroundColor = color;
            Console.Write($"{Name} placed (");
            Console.Write(Symbol);
            Console.Write($") in cell {cell}");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}