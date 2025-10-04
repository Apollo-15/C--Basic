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
            System.Console.Clear();
            System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
            System.Console.Write("\x1b[1m");
            System.Console.WriteLine("\n==============================");
            System.Console.Write("\x1b[0m");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Cyan;
            System.Console.Write("\x1b[1m");
            System.Console.WriteLine("   Welcome to Hangman!");
            System.Console.Write("\x1b[0m");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.DarkGreen;
            System.Console.Write("\x1b[1m");
            System.Console.WriteLine("==============================");
            System.Console.Write("\x1b[0m");
            System.Console.ResetColor();

            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine("1. Start New Game");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine("2. View Instructions");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Blue;
            System.Console.WriteLine("3. Settings");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine("4. Exit");
            System.Console.ResetColor();

            System.Console.ForegroundColor = System.ConsoleColor.Gray;
            System.Console.Write("\x1b[1m");
            System.Console.WriteLine("\n Select an option (1-4): ");
            string choice = System.Console.ReadLine();
            soundManager.PlayKeyPress();
            System.Console.Write("\x1b[0m");
            System.Console.ResetColor();

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
                    System.Console.ForegroundColor = System.ConsoleColor.Red;
                    System.Console.Write("\x1b[1m");
                    System.Console.WriteLine("Invalid choice. Please select a valid option.");
                    System.Console.Write("\x1b[0m");
                    System.Console.ResetColor();
                    ShowMainMenu();
                    break;
            }
        }

        public void StartNewGame()
        {
            System.Console.Clear();
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine("Starting a new game...");
            System.Console.ResetColor();
            GameManager game = new GameManager(soundManager, settings);
            game.StartGame();
        }

        public void ShowInstructions()
        {
            System.Console.Clear();
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("\nInstructions:");
            System.Console.ResetColor();
            System.Console.WriteLine("1. You have to guess the word by suggesting letters.");
            System.Console.WriteLine("2. You have a limited number of incorrect guesses.");
            System.Console.WriteLine("3. If you guess the word before running out of guesses, you win!");
            System.Console.WriteLine("4. If you run out of guesses, you lose. Try again!");
            System.Console.WriteLine("5. Good luck and have fun!\n");
            System.Console.ForegroundColor = ConsoleColor.Gray;
            System.Console.Write("Press Enter to return to the main menu...");
            System.Console.ResetColor();
            System.Console.ReadLine();
            soundManager.PlayKeyPress();
            ShowMainMenu();
        }

        public void ShowSettings()
        {
            System.Console.Clear();
            SettingsManager settingsManager = new SettingsManager(soundManager, settings);
            settingsManager.OpenMenu();
        }

        private void ExitGame()
        {
            System.Console.Clear();
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Exiting the game. Goodbye!");
            Console.ResetColor();
            Environment.Exit(0);
        }
    }
}
