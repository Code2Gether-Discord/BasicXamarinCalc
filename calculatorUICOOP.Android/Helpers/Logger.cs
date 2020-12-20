using System;
using System.IO;

using Android.App;

namespace calculatorUICOOP.Droid.Helpers
{
    public class Logger
    {
        /// <value>
        /// Gets the log file.
        /// </value>
        private readonly FileInfo _logFile;

        public Logger()
        {
            // Generate Log Directory
            const string LOG_DIRECTORY_NAME = "logs";
            var PRIVATE_EXTERNAL_STORAGE = Application.Context.GetExternalFilesDir(null);
            var logDir = new DirectoryInfo(Path.Combine(PRIVATE_EXTERNAL_STORAGE.AbsolutePath, LOG_DIRECTORY_NAME));

            if (!logDir.Exists)
                logDir.Create();

            // Generate Log File
            string logFileName = $"{DateTime.UtcNow:s}.log";
            var logFile = new FileInfo(Path.Combine(logDir.FullName, logFileName));

            using var _ = logFile.Create();
            _logFile = logFile;
        }

        public void Log(LogLevel level, string message)
        {
            using var log = _logFile.AppendText();
            log.WriteLine($"[{DateTime.UtcNow:s}] ({level}) - {message}");   // [2020-12-24T21:30:00] (INFO) - Ho Ho Ho! Merry Log Message
        }

        public void Log(LogLevel level, Exception exception) =>
            Log(level, $"Exception: {exception.Message}{Environment.NewLine}{exception.StackTrace}");
    }
}