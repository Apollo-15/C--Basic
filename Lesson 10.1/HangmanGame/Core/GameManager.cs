using System;
using System.Collections.Generic;
using System.Linq;
using HangmanGame.Data;
using HangmanGame.Menu;
using HangmanGame.Models;
using HangmanGame.Graphics;

namespace HangmanGame.Core
{
    public class GameManager
    {
        private Settings settings;
        private string? word;
        private string? category;
        private List<char> guessedLetters = new List<char>();
        private int remainingAttempts;
        private bool isGameOver;
        private readonly SoundManager soundManager;

        private WordLibrary library = new WordLibrary();
        private static Random random = new Random();

        private readonly FrameRenderer frameRenderer;
        private readonly TimerManager timer;
        private readonly Dictionary<char, string> letterStates = new();
        private readonly HangmanGraphics hangman;

        public GameManager(SoundManager soundManager, Settings settings)
        {
            this.soundManager = soundManager;
            this.settings = settings ?? throw new ArgumentNullException(nameof(settings));
            this.timer = new TimerManager();

            var keyboard = new KeyboardUI();
            var wordUI = new WordUI();
            var hangman = new HangmanGraphics();

            this.hangman = new HangmanGraphics();
            this.frameRenderer = new FrameRenderer(this.hangman, keyboard, wordUI);
        }

        public void StartGame()
        {
            System.Console.Clear();
            guessedLetters = new List<char>();
            remainingAttempts = hangman.GetMaxAttempts(settings.Difficulty);
            isGameOver = false;

            CategoryMenu();

            if (word == null)
            {
                System.Console.WriteLine("Error: word was not generated!");
                return;
            }

            System.Console.WriteLine($"Word has been chosen! Starting the game... (Category: {category})");
            timer.Start();
            RunGameLoop();
        }

        public void RunGameLoop()
        {
            while (!isGameOver)
            {
                string wordState = new string(word.Select(c => guessedLetters.Contains(char.ToUpper(c)) ? c : '_').ToArray());
                frameRenderer.Render(wordState, remainingAttempts, letterStates, timer, guessedLetters, category, settings.Difficulty);
                System.Console.Write("Enter the letter: ");
                var input = System.Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                char ToGuess = char.ToUpper(input[0]);

                if (guessedLetters.Contains(ToGuess))
                {
                    System.Console.WriteLine("You already guessed this letter!");
                    continue;
                }

                guessedLetters.Add(ToGuess);

                if (word.ToUpper().Contains(ToGuess))
                {
                    letterStates[ToGuess] = "correct";
                    soundManager.PlayCorrectLetter();
                }
                else
                {
                    letterStates[ToGuess] = "wrong";
                    remainingAttempts--;
                    soundManager.PlayWrongLetter();
                }

                if (word.All(c => guessedLetters.Contains(Char.ToUpper(c))) || remainingAttempts <= 0)
                {
                    isGameOver = true;

                    string finalWordState = new string(word.Select(c => guessedLetters.Contains(char.ToUpper(c)) ? c : '_').ToArray());
                    frameRenderer.Render(finalWordState, remainingAttempts, letterStates, timer, guessedLetters, category, settings.Difficulty);
                }
            }

            timer.Stop();

            ResultManager resultManager = new ResultManager();
            resultManager.ShowResult(word, guessedLetters, remainingAttempts, timer, settings.Difficulty);

            bool validChoice = false;
            while (!validChoice)
            {
                string action = resultManager.GetNextAction();
                switch (action)
                {
                    case "1":
                        validChoice = true;
                        MenuManager menu = new MenuManager(soundManager, settings);
                        menu.ShowMainMenu();
                        break;
                    case "2":
                        validChoice = true;
                        StartGame();
                        break;
                    case "3":
                        validChoice = true;
                        System.Environment.Exit(0);
                        break;
                    default:
                        System.Console.WriteLine("Invalid choice. Please enter 1, 2 or 3.");
                        break;
                }
            }
        }

        public void CategoryMenu()
        {
            System.Console.Clear();
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine("\n=====Category=List=====");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.White;
            System.Console.Write("\x1b[1m");
            System.Console.WriteLine("You want to choose category by yourself or give control to the AI to take it?:");
            System.Console.Write("\x1b[0m");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine("1. Yes");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine("2. No");
            System.Console.ResetColor();
            string choice = System.Console.ReadLine();
            soundManager.PlayKeyPress();

            switch (choice)
            {
                case "1": HumanPick(); break;
                case "2": BotPick(); break;
                default: System.Console.WriteLine("Invalid number. Please, input number from from 1 to 2"); break;
            }
        }
        
        private void HumanPick()
        {
            System.Console.Clear();
            var categories = library.GetCategories();
            for (int i = 0; i < categories.Count; i++)
            {
                System.Console.WriteLine($"{i + 1}. {categories[i]}");
            }

            if (int.TryParse(System.Console.ReadLine(), out int catIndex) && catIndex > 0 && catIndex <= categories.Count)
            {
                category = categories[catIndex - 1];
                word = library.GetRandomWord(category, settings.MinLength, settings.MaxLength);
                System.Console.WriteLine($"You picked: {category}, word generated!");
            }
            else
            {
                System.Console.WriteLine("Invalid category number.");
            }

        }

        private void BotPick()
        {
            System.Console.Clear();
            var categories = library.GetCategories();
            category = categories[random.Next(categories.Count())];
            word = library.GetRandomWord(category, settings.MinLength, settings.MaxLength);

            System.Console.WriteLine($"Bot picked: {category}, word generated!");
        }
    }
}
