using System;

namespace FileIOCopyApp.Models
{
    public class CopyResult
    {
        public bool Success { get; }
        public string Message { get; }

        public CopyResult(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }
    }
}