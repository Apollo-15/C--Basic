using System;
using HangmanGame.Core;
using HangmanGame.Models;
using System.Collections.Generic;

namespace HangmanGame
{
    public class ResultManager
    {
        public void ShowResult(string word, List<char> guessedLetters, int remainingAttempts, TimerManager timer, DifficultLevel difficulty)
        {
            TimeSpan duration = timer.GetElapsed();

            System.Console.ForegroundColor = System.ConsoleColor.Magenta;
            System.Console.WriteLine("\n==============================");
            System.Console.WriteLine("        GAME STATISTICS");
            System.Console.WriteLine("==============================");
            System.Console.ResetColor();

            if (remainingAttempts > 0)
            {
                System.Console.ForegroundColor = System.ConsoleColor.Green;
                System.Console.WriteLine("Congratulations! You won!");
            }
            else
            {
                System.Console.ForegroundColor = System.ConsoleColor.Red;
                System.Console.WriteLine("You lost. Better luck next time!");
            }
            System.Console.ResetColor();

            System.Console.ForegroundColor = System.ConsoleColor.Cyan;
            System.Console.WriteLine($"The word was: {word}");
            System.Console.ResetColor();

            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.Write("Guessed letters: ");
            foreach (var c in guessedLetters)
            {
                System.Console.Write(c + " ");
            }
            System.Console.WriteLine();
            System.Console.ResetColor();

            System.Console.ForegroundColor = System.ConsoleColor.Blue;
            System.Console.WriteLine($"Remaining attempts: {remainingAttempts}");
            System.Console.ResetColor();

            System.Console.ForegroundColor = System.ConsoleColor.DarkMagenta;
            System.Console.WriteLine($"Game duration: {duration.Minutes:D2}:{duration.Seconds:D2}");
            System.Console.ResetColor();

            System.Console.ForegroundColor = System.ConsoleColor.DarkYellow;
            System.Console.WriteLine($"Difficulty level: {difficulty}");
            System.Console.ResetColor();

            System.Console.ForegroundColor = System.ConsoleColor.Magenta;
            System.Console.WriteLine("==============================\n");
            System.Console.ResetColor();

            System.Console.WriteLine("What would you like to do next?");
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine("1. Return to Main Menu");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
            System.Console.WriteLine("2. Play Again");
            System.Console.ResetColor();
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine("3. Exit Game");
            System.Console.ResetColor();
        }

        public string GetNextAction()
        {
            string choice = System.Console.ReadLine();
            return choice;
        }
    }
}