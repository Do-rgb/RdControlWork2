using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyLib;
using Unity;

namespace ControlWork.StrFinderConsole
{
    [Serializable]
    public class FileSearcher : IComparable<FileSearcher>
    {
        public FileReport FileInfo { get; set; }
        public int CountFind { get; set; }
        private ILogger _logger;

        public static bool TryCreate(string pathToFile,string strToFind,out FileSearcher result)
        {
            result = null;
            
            if (string.IsNullOrEmpty(pathToFile)
                || string.IsNullOrEmpty(strToFind))
            {
                return false;
            }

            IEnumerable<string> lines = null;

            try
            {
                lines = File.ReadAllLines(pathToFile).FindStr(strToFind);
            }
            catch (IOException)
            {
                return false;
            }

            if (!lines.Any()) return false;
            
            result = new FileSearcher(UnityConfig.Container.Resolve<ILogger>(),new FileInfo(pathToFile), lines.Count());
            return true;
        }

        public FileSearcher() { }

        private FileSearcher(ILogger logger,FileInfo file,int countFind)
        {
            _logger = logger;
            FileInfo = new FileReport(file);
            CountFind = countFind;
            _logger.Write($"Найдено вхождение в файле:{file.FullName}.\nВхождений:{countFind}");
        }

        public int CompareTo(FileSearcher other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;

            //От меньшего к меньшему
            var result = CountFind.CompareTo(other.CountFind);
            //От большего к меньшему
            result *= -1;
            return result;
        }
    }
}