using System;
using System.Collections.Generic;
using System.IO;
using ControlWork.StrFinderConsole.ReportTask;
using Unity;

namespace ControlWork.StrFinderConsole
{
    internal class Program
    {
        private static void Main()
        {
            var currentDirectory = Directory.GetCurrentDirectory();

            Console.WriteLine("Введите строку для поиска:");

            var userInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(userInput)) Console.WriteLine("Неверная строка для поиска.");

            var _fileSearchers = new List<FileSearcher>();

            var searcher = new DirectorySearcher(currentDirectory, userInput, UnityConfig.Container.Resolve<ILogger>());

            Console.WriteLine("Найденные файлы:");
            foreach (var item in searcher)
            {
                _fileSearchers.Add(item);
                Console.WriteLine(item.FileInfo.FullName);
            }

            var report = new Report(_fileSearchers.ToArray(), userInput);

            report.ToXmlFile("report.xml");

            Console.WriteLine("Файл отчета записан в report.xml");

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}