using System;
using System.IO;

namespace FileIOCopyApp.Helpers
{
    public static class PathValidator
    {
        public static void ValidateSourcePath(string sourcePath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath))
                throw new ArgumentException("Source path is empty.");

            if (!File.Exists(sourcePath))
                throw new FileNotFoundException($"Source file not found at '{sourcePath}'.");
        }

        public static void ValidateDestinationPath(string destinationPath)
        {
            if (string.IsNullOrWhiteSpace(destinationPath))
                throw new ArgumentException("Destination path is empty.");

            string? fileDirection = Path.GetDirectoryName(destinationPath);
            if (!string.IsNullOrEmpty(fileDirection))
            {
                try
                {
                    Directory.CreateDirectory(fileDirection);
                }
                catch (UnauthorizedAccessException)
                {
                    throw new UnauthorizedAccessException($"Cannot create directory '{fileDirection}': access denied.");
                }
                catch (IOException ioEx)
                {
                    throw new IOException($"Cannot create directory '{fileDirection}': {ioEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unexpected error creating directory '{fileDirection}': {ex.Message}");
                }
            }
        }
    }
}