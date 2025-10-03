using System;
using HangmanGame.Core;
using HangmanGame.Models;

namespace HangmanGame.Menu
{
    public class MenuManager
    {
        private readonly SoundManager soundManager;
        private readonly Settings settings;

        public MenuManager(SoundManager soundManager, Settings settings)
        {
            this.soundManager = soundManager;
            this.settings = settings;
        }

        public void ShowMainMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\x1b[1m");
            Console.WriteLine("\n==============================");
            Console.Write("\x1b[0m");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\x1b[1m");
            Console.WriteLine("   Welcome to Hangman!");
            Console.Write("\x1b[0m");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("\x1b[1m");
            Console.WriteLine("==============================");
            Console.Write("\x1b[0m");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Start New Game");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("2. View Instructions");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("3. Settings");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("4. Exit");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\x1b[1m");
            Console.WriteLine("\n Select an option (1-4): ");
            string choice = Console.ReadLine();
            soundManager.PlayKeyPress();
            Console.Write("\x1b[0m");
            Console.ResetColor();

            HandleChoice(choice);
        }

        public void HandleChoice(string choice)
        {
            switch (choice)
            {
                case "1": StartNewGame(); break;
                case "2": ShowInstructions(); break;
                case "3": ShowSettings(); break;
                case "4": ExitGame(); break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\x1b[1m");
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    Console.Write("\x1b[0m");
                    Console.ResetColor();
                    ShowMainMenu();
                    break;
            }
        }

        public void StartNewGame()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Starting a new game...");
            Console.ResetColor();
            GameManager game = new GameManager(soundManager, settings);
            game.StartGame();
        }

        public void ShowInstructions()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nInstructions:");
            Console.ResetColor();
            Console.WriteLine("1. You have to guess the word by suggesting letters.");
            Console.WriteLine("2. You have a limited number of incorrect guesses.");
            Console.WriteLine("3. If you guess the word before running out of guesses, you win!");
            Console.WriteLine("4. If you run out of guesses, you lose. Try again!");
            Console.WriteLine("5. Good luck and have fun!\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Press Enter to return to the main menu...");
            Console.ResetColor();
            Console.ReadLine();
            soundManager.PlayKeyPress();
            ShowMainMenu();
        }

        public void ShowSettings()
        {
            SettingsManager settingsManager = new SettingsManager(soundManager, settings);
            settingsManager.OpenMenu();
        }

        private void ExitGame()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Exiting the game. Goodbye!");
            Console.ResetColor();
            Environment.Exit(0);
        }
    }
}
