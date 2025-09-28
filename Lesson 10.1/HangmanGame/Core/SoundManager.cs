using System;
using System.Media;

namespace HangmanGame.Core
{
    public class SoundManager
    {
        public void PlaySound(string soundFileName)
        {
            SoundPlayer player = new SoundPlayer($"Sounds/{soundFileName}.wav");
            player.Play();
        }

        public void PlayMenuOpen()
        {
            PlaySound("Menu/menu_open");
        }

        public void PlayMenuSelect()
        {
            PlaySound("Menu/menu_select");
        }

        public void PlayMenuInvalid()
        {
            PlaySound("Menu/menu_invalid");
        }

        public void PlayCorrectLetter()
        {
            PlaySound("Game/correct_letter");
        }

        public void PlayWrongLetter()
        {
            PlaySound("Game/wrong_letter");
            PlaySound("Game/writing");
        }

        public void PlayHint()
        {
            PlaySound("Game/hint");
        }

        public void PlayWordCompleted()
        {
            PlaySound("Game/word_completed");
        }

        public void PlayLoose()
        {
            PlaySound("Game/loose");
        }

        public void PlayKeyPress()
        {
            PlaySound("Interface/keyboard_click");
        }

        public void PlayTick()
        {
            PlaySound("Timer/tick");
        }
    }
}