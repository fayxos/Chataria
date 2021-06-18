namespace Chataria.Core
{
    /// <summary>
    /// The level of details to output for a logger
    /// </summary>
    public enum LogOutputLevel
    {
        /// <summary>
        /// Logs everything
        /// </summary>
        Debug = 1,

        /// <summary>
        /// Logs all except debug information
        /// </summary>
        Verbose = 2,

        /// <summary>
        /// Logs all informative messages, ignoring any debug and verbose messages
        /// </summary>
        Informative = 3,

        /// <summary>
        /// Logs only warnings, errors and succes, but no general information
        /// </summary>
        Critical = 4,

        /// <summary>
        /// The logger will never output anything
        /// </summary>
        Nothing = 7
    }
}
