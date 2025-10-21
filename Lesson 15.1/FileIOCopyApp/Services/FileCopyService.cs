using System;
using System.IO;
using FileIOCopyApp.Models;
using FileIOCopyApp.Helpers;


namespace FileIOCopyApp.Services
{
    public class FileCopyService
    {
        public CopyResult CopyFile(string sourcePath, string destinationPath)
        {
            try
            {
                PathValidator.ValidateSourcePath(sourcePath);
                PathValidator.ValidateDestinationPath(destinationPath);

                File.Copy(sourcePath, destinationPath, overwrite: true);

                return new CopyResult(true, $"FIle successfully copied to: {destinationPath}");
            }
            catch (Exception ex)
            {
                return new CopyResult(false, $"Error: {ex.Message}");
            }
        }
    }
}