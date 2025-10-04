using System;
using HangmanGame.Data;
using HangmanGame.Models;
using System.Threading;
using NAudio.Wave;

namespace HangmanGame.Core
{
    public class SoundManager : IDisposable
    {
        private readonly Settings settings;
        private WaveOutEvent? outputDevice;
        private AudioFileReader? audioFile;
        private WaveOutEvent? menuMusicDevice;
        private AudioFileReader? menuMusicFile;

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
                audioFile = new AudioFileReader($"Assets/Sounds/{soundFileName}.wav")
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
        public void PlayWrongLetter() => PlaySound("Game/wrong_letter");
        public void PlayWriting() => PlaySound("Game/writing");
        public void PlayWordCompleted() => PlaySound("Game/word_completed");
        public void PlayLoose() => PlaySound("Game/loose");
        public void PlayWin() => PlaySound("Game/win");
        public void PlayGameOver() => PlaySound("Game/game_over");
        public void PlayKeyPress() => PlaySound("Interface/keyboard_click");
        private void DisposeCurrentAudio()
        {
            outputDevice?.Stop();
            outputDevice?.Dispose();
            audioFile?.Dispose();
            outputDevice = null;
            audioFile = null;
        }
        public void Dispose() => DisposeCurrentAudio();

        public void Wait(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        public void PlayMenuMusic()
        {
            if (!settings.SoundEnabled)
                return;

            if (menuMusicDevice != null)
                return;

            try
            {
                menuMusicFile = new AudioFileReader("Assets/Sounds/Menu/menu_music.wav")
                {
                    Volume = settings.Volume / 10f
                };

                menuMusicDevice = new WaveOutEvent();
                menuMusicDevice.Init(menuMusicFile);
                menuMusicDevice.PlaybackStopped += (s, e) =>
                {
                    menuMusicDevice?.Dispose();
                    menuMusicFile?.Dispose();
                    menuMusicDevice = null;
                    menuMusicFile = null;
                };

                menuMusicDevice.Play();
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Error playing menu music: {e.Message}");
            }
        }

        public void StopMenuMusic()
        {
            menuMusicDevice?.Stop();
        }
    }
}