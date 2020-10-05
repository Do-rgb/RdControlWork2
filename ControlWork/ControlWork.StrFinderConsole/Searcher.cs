using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;

namespace ControlWork.StrFinderConsole
{
    class Searcher : IEnumerable<FileSearcher>
    {
        private const string TXT_PATTERN = "*.txt";
        
        private readonly string _dirPath;
        private readonly string _strToFind;
        private readonly ILogger _logger;

        public Searcher(string dirPath,string strToFind, ILogger logger)
        {
            _dirPath = dirPath ?? throw new ArgumentNullException(nameof(dirPath));
            _strToFind = strToFind ?? throw new ArgumentNullException(nameof(strToFind));
            _logger = logger;
        }

        public IEnumerator<FileSearcher> GetEnumerator()
        {
            _logger.Write($"Начат поиск файлов в каталоге:{_dirPath}");
            _logger.Write($"Ключевое слово:{_strToFind}");
            var txtFiles = Directory.GetFiles(_dirPath, TXT_PATTERN, SearchOption.AllDirectories);
            _logger.Write($"Найдено файлов txt:{txtFiles.Length}");
            
            foreach (var txtFile in txtFiles)
            {
                if (FileSearcher.TryCreate(txtFile, _strToFind,out var file ))
                {
                    yield return file;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}