using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace Chataria.Core.Logging
{
    /// <summary>
    /// The standard log factory for Chataria
    /// Logs details to the Console by default
    /// </summary>
    public class BaseLogFactory : ILogFactory
    {
        #region Protected Methods

        /// <summary>
        /// The list of loggers in this factory
        /// </summary>
        protected List<ILogger> mLoggers = new();

        /// <summary>
        /// A lock for the logger list to keep it thread-safe
        /// </summary>
        protected object mLoggersLock = new();

        #endregion

        #region Properties

        public LogOutputLevel LogOutputLevel { get; set; }

        /// <summary>
        /// if true, includes the origin of where the log message was logged from
        /// such as the class name, line number annd filename
        /// </summary>
        public bool IncludeLogOriginDetails { get; set; } = true;

        #endregion

        #region Events

        public event Action<(string Message, LogLevel Level)> NewLog = (details) => { };

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseLogFactory()
        {
            // Add the console logger by default
            AddLogger(new DebugLogger());
        }

        #endregion

        #region Methods

        public void AddLogger(ILogger logger)
        {
            // Lock the list so its thread-safe
            lock (mLoggersLock)
            {
                // if the logger is not alredy in the list...
                if(!mLoggers.Contains(logger))
                    // Add the logger to the list
                    mLoggers.Add(logger);
            }
        }

        public void RemoveLogger(ILogger logger)
        {
            // Lock the list so its thread-safe
            lock (mLoggersLock)
            {
                // if the logger is in the list...
                if (mLoggers.Contains(logger))
                    // remove the logger from the list
                    mLoggers.Remove(logger);
            }
        }

        public void Log(
            string message, 
            LogLevel level = LogLevel.Informative, 
            [CallerMemberName] string origin = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            // If we should not log hte message as the level is too low...
            if ((int)level < (int)LogOutputLevel)
                return;

            // If the user wants to know where the log originated from...
            if (IncludeLogOriginDetails)
                message = $"[{Path.GetFileName(filePath)} > {origin}() > Line {lineNumber}]\r\n{message}";

            // Log to all loggers
            mLoggers.ForEach(logger => logger.Log(message, level));

            // Inform listeners
            NewLog.Invoke((message, level));
        }

        #endregion
    }
}
