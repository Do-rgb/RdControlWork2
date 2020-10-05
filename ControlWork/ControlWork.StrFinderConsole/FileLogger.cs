using System;
using System.IO;

namespace ControlWork.StrFinderConsole
{
    public class FileLogger : ILogger, IDisposable
    {
        private readonly StreamWriter _logFile;

        public FileLogger(string logFile)
        {
            _logFile = new StreamWriter(File.OpenWrite(logFile))
            {
                AutoFlush = true
            };
            _logFile.WriteLine($"Запуск от {DateTime.Now}");
        }

        public void Dispose()
        {
            _logFile.Close();
            _logFile?.Dispose();
        }

        public void Write(string message)
        {
            _logFile.WriteLine(message);
        }
    }
}