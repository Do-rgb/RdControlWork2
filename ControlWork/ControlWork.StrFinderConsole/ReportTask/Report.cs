using System;

namespace ControlWork.StrFinderConsole.ReportTask
{
    [Serializable]
    public class Report
    {
        public Report()
        {
        }

        public Report(FileSearcher[] files, string strToFind)
        {
            Files = files;
            StrToFind = strToFind;
            Array.Sort(Files);
        }

        public string StrToFind { get; set; }
        public FileSearcher[] Files { get; set; }
    }
}