using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;
using Unity;

namespace ControlWork.StrFinderConsole
{

    class Program
    {
        static void Main()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            
            Console.WriteLine("Введите строку для поиска:");

            string userInput = Console.ReadLine();
            
            if (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine("Неверная строка для поиска.");
            }
            
            List<FileSearcher> _fileSearchers = new List<FileSearcher>();
            
            Searcher searcher = new Searcher(currentDirectory,userInput,UnityConfig.Container.Resolve<ILogger>());

            foreach (var item in searcher)
            {
                _fileSearchers.Add(item);
            }
            
            Report report = new Report(_fileSearchers.ToArray(),userInput);
            Console.WriteLine("Найденные файлы:");
            foreach (var item in report.Files)
            {
                Console.WriteLine(item.FileInfo.FullName);
            }

            XmlSerializer formatter = new XmlSerializer(typeof(Report));

            using (FileStream fs = new FileStream("report.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, report);

                Console.WriteLine("Файл отчета записан в report.xml");
            }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
