using System;
using HangmanGame.Menu;
using HangmanGame.Core;
using HangmanGame.Models;

namespace HangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Settings settings = new Settings();
            SoundManager soundManager = new SoundManager(settings);

            MenuManager menu = new MenuManager(soundManager, settings);
            menu.ShowMainMenu();
        }
    }
}
