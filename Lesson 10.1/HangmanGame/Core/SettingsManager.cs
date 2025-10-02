using System;
using Data;

namespace HangmanGame.Core
{
    public class SettingsManager
    {
        private WordLibrary library = new WordLibrary();
        private static Random random = new Random();
        private Settings settings;
        private string category;
        private string word;

        public SettingsManager()
        {
            settings = new Settings();
        }

        public void OpenMenu()
        {
            System.Console.ForegroundColor = System.ConsoleColor.Cyan;
            System.Console.WriteLine("\n=====Settings=List=====");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine("1. Difficulty");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine("2. Category");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine("3. Sound");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
            System.Console.WriteLine("4. Exit");
            System.Console.ResetColor();

            string choice = System.Console.ReadLine();

            switch (choice)
            {
                case "1": DifficultyMenu(); break;
                case "2": CategoryMenu(); break;
                case "3": SoundMenu(); break;
                default: System.Console.WriteLine("Invalid number. Please, input number from from 1 to 4"); break;
            }
        }

        public void DifficultyMenu()
        {
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

            switch (choice)
            {
                case "1":
                    settings.Difficulty = DifficultLevel.Easy;
                    settings.MinLength = 3;
                    settings.MaxLength = 7;
                    settings.MaxAttempts = 12;
                    break;
                case "2":
                    settings.Difficulty = DifficultLevel.Medium;
                    settings.MinLength = 5;
                    settings.MaxLength = 10;
                    settings.MaxAttempts = 6;
                    break;
                case "3":
                    settings.Difficulty = DifficultLevel.Hard;
                    settings.MinLength = 7;
                    settings.MaxLength = 15;
                    settings.MaxAttempts = 3;
                    break;
                case "4": OpenMenu(); break;
                default: System.Console.WriteLine("Invalid number. Please, input number from from 1 to 4"); break;
            }
        }

        public void CategoryMenu()
        {
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
            System.Console.ForegroundColor = System.Console.DarkRed;
            System.Console.WriteLine("3. Exit");
            System.Console.ResetColor();

            string choice = System.Console.ReadLine();

            switch (choice)
            {
                case "1": HumanPick(); break;
                case "2": BotPick(); break;
                case "3": OpenMenu(); break;
                default: System.Console.WriteLine("Invalid number. Please, input number from from 1 to 3"); break;
            }
        }

        public void SoundMenu()
        {
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

            string choice = System.Console.ReadLine(); ;

            switch (choice)
            {
                case "1":
                    settings.SoundEnabled = true;
                    System.Console.WriteLine("Sound enabled.");
                    break;
                case "2":
                    settings.SoundEnabled = false;
                    System.Console.WriteLine("Sound disabled.");
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
                    break;
                case "4": OpenMenu(); break;
                default: System.Console.WriteLine("Invalid number. Please, input number from from 1 to 4"); break;
            }
        }

        private void HumanPick()
        {
            var categories = WordLibrary.GetCategories();
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
            var categories = WordLibrary.GetCategories();
            category = categories[random.Next(categories.Count())];
            word = library.GetRandomWord(category, settings.MinLength, settings.MaxLength);

            System.Console.WriteLine($"Bot picked: {category}, word generated!");
        }
    }
}