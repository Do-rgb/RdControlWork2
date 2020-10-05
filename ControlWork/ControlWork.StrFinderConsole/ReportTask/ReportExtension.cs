using System.IO;
using System.Xml.Serialization;

namespace ControlWork.StrFinderConsole.ReportTask
{
    public static class ReportExtension
    {
        public static void ToXmlFile(this Report report, string fileName)
        {
            var formatter = new XmlSerializer(typeof(Report));

            using (var fs = new FileStream("report.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, report);
            }
        }
    }
}