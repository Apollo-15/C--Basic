namespace Tic_tac_toe
{
    public class HumanPlayer(string name, char symbol) : IPlayer
    {
        public char Symbol { get; private set; } = symbol;
        public string Name { get; private set; } = name;


        public int ChooseCell(Board board)
        {
            int cell;
            while (true)
            {
                System.Console.Write($"{Name}, enter your move (1-9): ");
                if (int.TryParse(System.Console.ReadLine(), out cell) &&
                    cell >= 1 && cell <= 9 &&
                    board.IsCellEmpty(cell - 1))
                {
                    break;
                }
                System.Console.WriteLine("Invalid move. Try again.");
            }
            return cell - 1;
        }

        public void MakeMove(Board board)
        {
            int cell = ChooseCell(board);
            int playerNumber = Symbol == 'X' ? 1 : 2;
            board.PlaceMark(cell, playerNumber);
        }
    }
}