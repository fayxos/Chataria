using System;

namespace Chataria.Core
{
    /// <summary>
    /// Logs to a specific file
    /// </summary>
    public class FileLogger : ILogger
    {
        #region Public Properties

        /// <summary>
        /// The path to write the log file to
        /// </summary>
        public string FilePath { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="filePath"></param>
        public FileLogger(string filePath)
        {
            // Set the file path property
            FilePath = filePath; 
        }

        #endregion

        #region Logger Methods

        public void Log(string message, LogLevel level)
        {
            // Get current time
            var currentTime = DateTimeOffset.Now.ToString(" dd.MM.yyyy HH:mm.ss");

            // Write the message to the log file
            IoC.File.WriteAllTextToFileAsync($"[{currentTime }] " + message + Environment.NewLine, FilePath, append: true);
        } 

        #endregion
    }
}
