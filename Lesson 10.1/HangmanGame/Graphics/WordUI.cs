using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanGame.Graphics
{
    public class WordUI
    {
        public void Draw(string word, List<char> guessedLetters)
        {
            System.Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.WriteLine("\n=====Word to guess=====\n");

            string display = "";
            foreach (char c in word)
            {
                display += guessedLetters.Contains(char.ToUpper(c)) || guessedLetters.Contains(char.ToLower(c)) 
                    ? c + " " 
                    : "_ ";
            }
            display = display.TrimEnd();

            int length = display.Length;

            System.Console.Write("╔");
            System.Console.Write(new string('═', length));
            System.Console.WriteLine("╗");
            System.Console.Write("║");
            System.Console.Write(display);
            System.Console.WriteLine("║");
            System.Console.Write("╚");
            System.Console.Write(new string('═', length));
            System.Console.WriteLine("╝");
            System.Console.ResetColor();
            System.Console.WriteLine();
        }
    }
}
