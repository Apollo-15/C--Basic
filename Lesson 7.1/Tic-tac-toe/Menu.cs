namespace Tic_tac_toe
{
    public class Menu
    {
        public void ShowMainMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n==============================");
                Console.WriteLine("   Welcome to Tic-Tac-Toe!");
                Console.WriteLine("==============================");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Start Game");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("2. Exit");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter your choice here: ");
                Console.ResetColor();

                string choice = System.Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateGame();
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Exiting the game...");
                        Console.ResetColor();
                        isRunning = false;
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Invalid choice. Try again.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        bool ChooseMode()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.Write("Choose game mode: \n");
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("1. Human vs Human");
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("2. Human vs Bot");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.Write("Enter your choice here: ");
                Console.ResetColor();
                string mode = System.Console.ReadLine();
                if (mode == "1")
                {
                    return false;
                }
                else if (mode == "2")
                {
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    System.Console.WriteLine("Invalid choice. Try again.");
                    Console.ResetColor();
                }
            }
        }

        char ChooseSymbol()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Would you like to choose your symbol or let the bot choose for you?");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. I will choose my symbol");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("2. Let the bot choose for me");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter your choice here: ");
                Console.ResetColor();
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Choose your symbol (X/O): ");
                        Console.ResetColor();
                        string symbol = Console.ReadLine().ToUpper();
                        if (symbol == "X" || symbol == "O")
                        {
                            return symbol[0];
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Invalid choice. Try again.");
                            Console.ResetColor();
                        }
                    }
                }
                else if (choice == "2")
                {
                    char[] symbols = { 'X', 'O' };
                    Random rnd = new Random();
                    char selected = symbols[rnd.Next(symbols.Length)];
                    Console.ForegroundColor = selected == 'X' ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.WriteLine($"Bot chose: {selected}");
                    Console.ResetColor();
                    return selected;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Invalid choice. Try again.");
                    Console.ResetColor();
                }
            }
        }

        public void CreateGame()
        {
            bool ifVersusBot = ChooseMode();
            char playerSymbol = ChooseSymbol();
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.Write("Enter name for Player 1: ");
            Console.ResetColor();
            string firstPlayerName = System.Console.ReadLine() ?? "Player1";
            IPlayer player1 = new HumanPlayer(firstPlayerName, playerSymbol);

            IPlayer player2;
            if (ifVersusBot)
            {
                List<string> botNames = new List<string> { "Steve", "Eva", "Neo", "Max", "Alice", "John", "Mira", "Oscar" };

                botNames.RemoveAll(name => name.Equals(firstPlayerName, StringComparison.OrdinalIgnoreCase));

                if (botNames.Count == 0)
                    botNames.Add("DefaultBot");

                Random random = new Random();
                string botName = botNames[random.Next(botNames.Count)];
                char botSymbol = playerSymbol == 'X' ? 'O' : 'X';
                player2 = new BotPlayer(botName, botSymbol);
                Console.ForegroundColor = botSymbol == 'X' ? ConsoleColor.Green : ConsoleColor.Red;
                System.Console.WriteLine($"Bot's name is {botName} and its symbol is {botSymbol}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.Write("Enter name for Player 2: ");
                Console.ResetColor();
                string secondPlayerName = System.Console.ReadLine() ?? "Player2";
                char secondPlayerSymbol = playerSymbol == 'X' ? 'O' : 'X';
                player2 = new HumanPlayer(secondPlayerName, secondPlayerSymbol);
            }

            Game game = new Game(player1, player2);
            game.StartGame();
        }
    }
}