using System;
using System.IO;

namespace ControlWork.StrFinderConsole
{
    [Serializable]
    public class FileReport
    {
        public FileReport()
        {
        }

        public FileReport(FileInfo fileInfo)
        {
            SimpleName = fileInfo.Name;
            FullName = fileInfo.FullName;
            Directory = fileInfo.Directory.FullName;
            LastWriteTime = fileInfo.LastWriteTimeUtc;
            Size = fileInfo.Length;
        }

        public string SimpleName { get; set; }
        public string FullName { get; set; }
        public string Directory { get; set; }
        public DateTime LastWriteTime { get; set; }
        public long Size { get; set; }
    }
}