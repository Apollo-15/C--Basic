using System;
using HangmanGame.Data;
using HangmanGame.Models;
using HangmanGame.Menu;

namespace HangmanGame.Core
{
    public class SettingsManager
    {
        private readonly SoundManager soundManager;
        private WordLibrary library = new WordLibrary();
        private MenuManager menuManager;
        private static Random random = new Random();
        private Settings settings;

        public SettingsManager(SoundManager soundManager, Settings settings)
        {
            this.settings = settings;
            this.soundManager = soundManager;
            this.menuManager = new MenuManager(soundManager, this.settings);
        }

        public void OpenMenu()
        {
            System.Console.Clear();
            System.Console.ForegroundColor = System.ConsoleColor.Cyan;
            System.Console.WriteLine("\n=====Settings=List=====");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine("1. Difficulty");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine("2. Sound");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
            System.Console.WriteLine("3. Exit");
            System.Console.ResetColor();

            string choice = System.Console.ReadLine();
            soundManager.PlayKeyPress();

            switch (choice)
            {
                case "1": DifficultyMenu(); break;
                case "2": SoundMenu(); break;
                case "3": menuManager.ShowMainMenu(); break;
                default: System.Console.WriteLine("Invalid number. Please, input number from from 1 to 3"); break;
            }
        }

        public void DifficultyMenu()
        {
            System.Console.Clear();
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine("\n=====Difficulty=List=====");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine("1. Easy");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine("2. Normal");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine("3. Hard");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
            System.Console.WriteLine("4. Exit");
            System.Console.ResetColor();

            string choice = System.Console.ReadLine();
            soundManager.PlayKeyPress();

            switch (choice)
            {
                case "1":
                    settings.Difficulty = DifficultLevel.Easy;
                    settings.MinLength = 3;
                    settings.MaxLength = 7;
                    settings.MaxAttempts = 12;
                    OpenMenu();
                    break;
                case "2":
                    settings.Difficulty = DifficultLevel.Medium;
                    settings.MinLength = 5;
                    settings.MaxLength = 10;
                    settings.MaxAttempts = 6;
                    OpenMenu();
                    break;
                case "3":
                    settings.Difficulty = DifficultLevel.Hard;
                    settings.MinLength = 7;
                    settings.MaxLength = 15;
                    settings.MaxAttempts = 3;
                    OpenMenu();
                    break;
                case "4": OpenMenu(); break;
                default: System.Console.WriteLine("Invalid number. Please, input number from from 1 to 4"); break;
            }
        }

        public void SoundMenu()
        {
            System.Console.Clear();
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine("=====Sound=Settings=====");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine("1. Enable sound");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine("2. Disable sound");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Blue;
            System.Console.WriteLine("3. Set volume(0-10)");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
            System.Console.WriteLine("4. Exit");
            System.Console.ResetColor();

            string choice = System.Console.ReadLine();
            soundManager.PlayKeyPress();

            switch (choice)
            {
                case "1":
                    settings.SoundEnabled = true;
                    System.Console.WriteLine("Sound enabled.");
                    SoundMenu();
                    break;
                case "2":
                    settings.SoundEnabled = false;
                    System.Console.WriteLine("Sound disabled.");
                    SoundMenu();
                    break;
                case "3":
                    System.Console.WriteLine("Enter volume (0-10, default - 5)");
                    int volume;
                    if (int.TryParse(System.Console.ReadLine(), out volume) && volume >= 0 && volume <= 10)
                    {
                        settings.Volume = volume;
                        System.Console.WriteLine($"Volume set to {volume}");
                    }
                    else
                    {
                        System.Console.WriteLine("Invalid number! Volume number must be from 0 to 10.");
                    }
                    SoundMenu();
                    break;
                case "4": OpenMenu(); break;
                default:
                    System.Console.WriteLine("Invalid number. Please, input number from from 1 to 4");
                    SoundMenu();
                    break;
            }
        }
    }
}