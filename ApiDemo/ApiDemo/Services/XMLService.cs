using System.Xml;

namespace ApiDemo.Services
{
    public static class XMLService
    {
        public static void GenerateXMLFile()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlElement studentDataNode = doc.CreateElement("StudentData");
            (studentDataNode).SetAttribute("xmlns:xsi", "http://www.abc.com");
            (studentDataNode).SetAttribute("schemaLocation", "http://www.abc.com/XMLSchema-instance", "http://www.abc.com/ aaa.sxd");
            (studentDataNode).SetAttribute("xmlns", "http://www.abc.com/");
            doc.AppendChild(docNode);

            XmlNode headerNode = doc.CreateElement("Header");
            studentDataNode.AppendChild(headerNode);

            XmlNode contentDataNode = doc.CreateElement("ContentDate");
            studentDataNode.AppendChild(doc.CreateTextNode("2023-08-22"));
            headerNode.AppendChild(contentDataNode);

            XmlNode studentRecordsNode = doc.CreateElement("StudentRecords");
            studentRecordsNode.AppendChild(studentRecordsNode);

            XmlNode studentRecordNode = doc.CreateElement("StudentRecord");
            studentRecordNode.AppendChild(studentRecordNode);

            XmlNode studentNameNode = doc.CreateElement("StudentName");
            studentNameNode.AppendChild(doc.CreateTextNode("SirAndre"));
            studentRecordNode.AppendChild(studentNameNode);

            XmlNode studentNameNode = doc.CreateElement("StudentName");
            studentNameNode.AppendChild(doc.CreateTextNode("SirAndre"));
            studentRecordNode.AppendChild(studentNameNode);
        }
    }
}
