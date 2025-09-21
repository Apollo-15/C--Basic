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
                System.Console.WriteLine("Welcome to Tic-Tac-Toe!");
                System.Console.WriteLine("1. Start Game");
                System.Console.WriteLine("2. Exit");
                System.Console.Write("Enter your choice here: ");
                Console.ResetColor();

                string choice = System.Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateGame();
                        break;
                    case "2":
                        Console.WriteLine("Exiting the game...");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        bool ChooseMode()
        {
            while (true)
            {
                System.Console.Write("Choose game mode: \n1. Human vs Human \n2. Human vs Bot \nEnter your choice here: ");
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
                    System.Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        char ChooseSymbol()
        {
            while (true)
            {
                Console.WriteLine("Would you like to choose your symbol or let the bot choose for you?");
                Console.WriteLine("1. I will choose my symbol");
                Console.WriteLine("2. Let the bot choose for me");
                Console.Write("Enter your choice here: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    while (true)
                    {
                        Console.Write("Choose your symbol (X/O): ");
                        string symbol = Console.ReadLine().ToUpper();
                        if (symbol == "X" || symbol == "O")
                        {
                            return symbol[0];
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Try again.");
                        }
                    }
                }
                else if (choice == "2")
                {
                    char[] symbols = { 'X', 'O' };
                    Random rnd = new Random();
                    char selected = symbols[rnd.Next(symbols.Length)];
                    Console.WriteLine($"Bot chose: {selected}");
                    return selected;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }

        public void CreateGame()
        {
            bool ifVersusBot = ChooseMode();
            char playerSymbol = ChooseSymbol();
            System.Console.Write("Enter name for Player 1: ");
            string firstPlayerName = System.Console.ReadLine();
            Player player1 = new Player(firstPlayerName, playerSymbol);

            Player player2;
            if (ifVersusBot)
            {
                List<string> botNames = new List<string> { "Steve", "Eva", "Neo", "BotMax", "Alice", "John", "Mira", "Oscar" };

                botNames.RemoveAll(name => name.Equals(firstPlayerName, StringComparison.OrdinalIgnoreCase));

                if (botNames.Count == 0)
                    botNames.Add("DefaultBot");

                Random random = new Random();
                string botName = botNames[random.Next(botNames.Count)];
                char botSymbol = playerSymbol == 'X' ? 'O' : 'X';
                player2 = new BotPlayer(botName, botSymbol);
                System.Console.WriteLine($"Bot's name is {botName} and its symbol is {botSymbol}");
            }
            else
            {
                System.Console.Write("Enter name for Player 2: ");
                string secondPlayerName = System.Console.ReadLine();
                char secondPlayerSymbol = playerSymbol == 'X' ? 'O' : 'X';
                player2 = new Player(secondPlayerName, secondPlayerSymbol);
            }

            Game game = new Game(player1, player2);
            game.StartGame();
        }
    }
}