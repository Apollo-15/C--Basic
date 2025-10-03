using System;

namespace HangmanGame.Core
{
    public class TimerManager
    {
        private DateTime startTime;
        private TimeSpan elapsed;
        private bool isRunning;

        public void Start()
        {
            startTime = DateTime.Now;
            isRunning = true;
        }

        public TimeSpan Stop()
        {
            if (isRunning)
            {
                elapsed = DateTime.Now - startTime;
                isRunning = false;
            }
            return elapsed;
        }

        public TimeSpan GetElapsed()
        {
            if (isRunning)
            {
                return DateTime.Now - startTime;
            }
            return elapsed;
        }

        public string GetFormattedTime()
        {
            var time = GetElapsed();
            return $"{time.Minutes:D2}:{time.Seconds:D2}";
        }
    }
}