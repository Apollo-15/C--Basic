using System;
using HangmanGame.Core;
using HangmanGame.Models;

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

        public void Render(string word, int remainingAttempts, Dictionary<char, string> letterStates, TimerManager timer, List<char> guessedLetters, string category, DifficultLevel difficulty)
        {
            System.Console.Clear();
            
            wordUI.Draw(word, guessedLetters, category);

            hangmanGraphics.Draw(remainingAttempts, difficulty);

            keyboardUI.Draw(letterStates);
        }
    }
}