﻿using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Chataria.Core
{
    /// <summary>
    /// Handles reading/writing and quering the file system
    /// </summary>
    public class FileManager : IFileManager
    {
        /// <summary>
        /// Writes the text to the specified file
        /// </summary>
        /// <param name="text">The text to write</param>
        /// <param name="path">The path of the file to write to</param>
        /// <param name="append">If true, writes the text to the end of the file, otherwise overrides any existing file</param>
        /// <returns></returns>
        public async Task WriteAllTextToFileAsync(string text, string path, bool append = false)
        {
            // TODO: Add exception catching

            // Normalize path
            path = NormalizePath(path);

            // Resolve to absolute path
            path = ResolvePath(path);

            // Lock the task
            await AsyncAwaiter.AwaitAsync(nameof(FileManager) + path, async () =>
            {
                // TODO: Add IoC.Task.Run that logs to logger on failure

                // Run the synchronous file access as a new task
                await IoC.Task.Run(() =>
                {
                    // Write the log message to file
                    using (var fileStream = (TextWriter)new StreamWriter(File.Open(path, append ? FileMode.Append : FileMode.Create)))
                        fileStream.Write(text);
                });
            });
        }

        public string NormalizePath(string path)
        {
            // If on Windows...
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                // Replace any / with \
                return path.Replace('/', '\\').Trim();
            // If on Linux or Mac...
            else
                // Replace any \ with /
                return path.Replace('\\', '/').Trim();
        }

        public string ResolvePath(string path)
        {
            // Resolve the path to absolute
            return Path.GetFullPath(path);
        }
    }
}
