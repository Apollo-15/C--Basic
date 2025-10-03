using System;
using HangmanGame.Data;
using HangmanGame.Models;
using NAudio.Wave;

namespace HangmanGame.Core
{
    public class SoundManager : IDisposable
    {
        private readonly Settings settings;
        private WaveOutEvent? outputDevice;
        private AudioFileReader? audioFile;

        public SoundManager(Settings settings)
        {
            this.settings = settings;
        }

        public void PlaySound(string soundFileName)
        {
            if (!settings.SoundEnabled)
            {
                return;
            }

            DisposeCurrentAudio();

            try
            {
                audioFile = new AudioFileReader($"Sounds/{soundFileName}.wav")
                {
                    Volume = settings.Volume / 10f // for example  0-10 will be 0.0-0.10
                };

                outputDevice = new WaveOutEvent();
                outputDevice.Init(audioFile);
                outputDevice.Play();
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Error playing sound \"{soundFileName}\": {e.Message}");
            }
        }

        public void PlayMenuOpen() => PlaySound("Menu/menu_open");
        public void PlayMenuSelect() => PlaySound("Menu/menu_select");
        public void PlayMenuInvalid() => PlaySound("Menu/menu_invalid");
        public void PlayCorrectLetter() => PlaySound("Game/correct_letter");
        public void PlayWrongLetter()
        {
            PlaySound("Game/wrong_letter");
            PlaySound("Game/writing");
        }
        public void PlayHint() => PlaySound("Game/hint");
        public void PlayWordCompleted() => PlaySound("Game/word_completed");
        public void PlayLoose() => PlaySound("Game/loose");
        public void PlayKeyPress() => PlaySound("Interface/keyboard_click");
        public void PlayTick() => PlaySound("Timer/tick");
        private void DisposeCurrentAudio()
        {
            outputDevice?.Stop();
            outputDevice?.Dispose();
            audioFile?.Dispose();
            outputDevice = null;
            audioFile = null;
        }
        public void Dispose() => DisposeCurrentAudio();
    }
}