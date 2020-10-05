using System.IO;
using System.Xml.Serialization;

namespace ControlWork.StrFinderConsole.ReportTask
{
    public static class ReportExtension
    {
        public static void ToXmlFile(this Report report, string fileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Report));

            using (FileStream fs = new FileStream("report.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, report);
            }
        }
    }
}