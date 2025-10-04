using System;
using System.Collections.Generic;

namespace HangmanGame.Graphics
{
    public class KeyboardUI
    {
        private readonly string[][] keyboard =
        {
            new string[] { "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P" },
            new string[] { "A", "S", "D", "F", "G", "H", "J", "K", "L" },
            new string[] { "Z", "X", "C", "V", "B", "N", "M" }
        };

        public void Draw(Dictionary<char, string> letterStates)
        {
            for (int row = 0; row < keyboard.Length; row++)
            {
                string[] letters = keyboard[row];

                string top = "";
                string mid = "";
                string bot = "";

                foreach (string letter in letters)
                {
                    char c = letter[0];
                    string color = GetColorForLetter(c, letterStates);
                    top += "╔═══╗";
                    mid += $"‖ {color}{letter}\x1b[0m ‖";
                    bot += "╚═══╝";
                }

                string offSet = new string(' ', row * 2);

                System.Console.WriteLine(offSet + top);
                System.Console.WriteLine(offSet + mid);
                System.Console.WriteLine(offSet + bot);
            }
        }

        private string GetColorForLetter(char letter, Dictionary<char, string> states)
        {
            char upperLetter = char.ToUpper(letter);

            if (states.ContainsKey(upperLetter))
            {
                string state = states[upperLetter];
                if (state == "correct")
                    return "\x1b[32;1m";
                if (state == "wrong")
                    return "\x1b[31;1m";
            }
            
            return "\x1b[37;1m";
        }
    }
}