using System;

namespace HangmanGame.Models
{
    public class Settings
    {
        public DifficultLevel Difficulty { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public int MaxAttempts { get; set; }
        public string? Theme { get; set; }
        public bool SoundEnabled { get; set; }
        public int Volume { get; set; } = 5;

        public Settings()
        {
            Difficulty = DifficultLevel.Medium;
            MinLength = 5;
            MaxLength = 10;
            MaxAttempts = 6;
            SoundEnabled = true;
            Volume = 5;
        }
    }

    public enum DifficultLevel
    {
        Easy,
        Medium,
        Hard
    }

}