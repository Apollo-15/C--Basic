namespace Tic_tac_toe
{
    public class Game
    {
        private IPlayer[] players;
        private int currentPlayerIndex;
        private DateTime startTime;
        private DateTime endTime;
        private int moveCount;
        private string winnerName = null;

        public Game(IPlayer player1, IPlayer player2)
        {
            players = new IPlayer[] { player1, player2 };
            currentPlayerIndex = 0;
        }

        public void StartGame()
        {
            Board.ResetBoard();
            Board.DisplayBoard();
            moveCount = 0;
            startTime = DateTime.Now;

            // Game loop
            while (true)
            {
                players[currentPlayerIndex].MakeMove();
                moveCount++;
                Board.DisplayBoard();

                if (CheckGameState(players[currentPlayerIndex]))
                    break;

                SwitchPlayer();
            }

            endTime = DateTime.Now;
            ShowStatistics();
        }

        public void SwitchPlayer()
        {
            currentPlayerIndex = 1 - currentPlayerIndex;
        }

        public bool CheckGameState(IPlayer player)
        {
            int playerNum = player.Symbol == 'X' ? 1 : 2;
            if (Board.IsWin(playerNum))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{player.Name} wins!");
                Console.ResetColor();
                winnerName = player.Name;
                return true;
            }
            if (Board.IsDraw())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Draw!");
                Console.ResetColor();
                winnerName = "Draw";
                return true;
            }
            return false;
        }

        private void ShowStatistics()
        {
            TimeSpan duration = endTime - startTime;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n==============================");
            Console.WriteLine("      GAME STATISTICS");
            Console.WriteLine("==============================");
            Console.ResetColor();

            if (winnerName == "Draw")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Winner: Draw");
            }
            else if (winnerName != null)
            {
                Console.ForegroundColor = winnerName == players[0].Name ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write("Winner: ");
                Console.Write("\x1b[1m");
                Console.WriteLine(winnerName);
                Console.Write("\x1b[0m");
            }
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Total moves: {moveCount}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"Game duration: {duration.Minutes} min {duration.Seconds} sec");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Started at: {startTime}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Ended at: {endTime}");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("==============================\n");
            Console.ResetColor();
        }
    }
}