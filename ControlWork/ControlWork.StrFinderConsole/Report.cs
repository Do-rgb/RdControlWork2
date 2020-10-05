using System;
using System.Collections;

namespace ControlWork.StrFinderConsole
{
    [Serializable]
    public class Report
    {

        public string StrToFind { get; set; }
        public FileSearcher[] Files { get; set; }
        public Report() { }
        public Report(FileSearcher[] files,string strToFind)
        {
            Files = files;
            StrToFind = strToFind;
            Array.Sort(Files);
        }
    }
}