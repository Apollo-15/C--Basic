using System;
using HangmanGame.Core;

namespace HangmanGame.Graphics
{
    public class FrameRenderer
    {
        private readonly HangmanGraphics hangmanGraphics;
        private readonly KeyboardUI keyboardUI;
        private readonly WordUI wordUI;

        public FrameRenderer(HangmanGraphics hangmanGraphics, KeyboardUI keyboardUI, WordUI wordUI)
        {
            this.hangmanGraphics = hangmanGraphics;
            this.keyboardUI = keyboardUI;
            this.wordUI = wordUI;
        }

        public void Render(string wordState, int remainingAttempts, Dictionary<char, string> letterStates, TimerManager timer)
        {
            System.Console.Clear();

            System.Console.ForegroundColor = System.ConsoleColor.Cyan;
            System.Console.WriteLine($"Word: {wordState}    Time: {timer.GetFormattedTime()}");
            System.Console.ResetColor();
            System.Console.WriteLine();

            hangmanGraphics.Draw(remainingAttempts);
            System.Console.WriteLine();

            keyboardUI.Draw(letterStates);
        }
    }
}