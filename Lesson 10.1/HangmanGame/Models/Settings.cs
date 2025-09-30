using System;

namespace HangmanGame.Models
{
    public class Settings
    {
        public DifficultLevel Difficulty { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; set; }
        public int MaxAttempts { get; set; }
        public string Theme { get; set; }
        public bool SoundEnabled { get; set; }
    }

    public enum DifficultLevel
    {
        Easy,
        Medium,
        Hard
    }

}