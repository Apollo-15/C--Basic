using System;

namespace HangmanGame.Models
{
    public class GameResult
    {
        public string? Word { get; set; }
        public bool IsWin { get; set; }
        public int AttemptsUsed { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime Date { get; set; }
        public DifficultLevel Difficulty { get; set; }
    }
}