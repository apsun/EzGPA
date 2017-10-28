using System.Xml;
using System.Xml.Linq;

namespace EzGPA.Config
{
    internal static class XmlHelper
    {
        public static XmlException CreateException(XElement element, string message)
        {
            IXmlLineInfo lineInfo = element;
            return new XmlException(message, null, lineInfo.LineNumber, lineInfo.LinePosition);
        }

        public static XElement LoadRoot(string filePath)
        {
            return GetRoot(XDocument.Load(filePath));
        }

        public static XElement GetRoot(XDocument doc)
        {
            XElement root = doc.Root;
            if (root == null)
                throw new XmlException("XML document contains no root element");
            return root;
        }

        public static string GetElementValue(XElement element, string elementName)
        {
            string value = GetElementValueOrDefault(element, elementName);
            if (value == null)
                throw CreateException(element, "Element contains no child with name " + elementName);
            return value;
        }

        public static string GetAttributeValue(XElement element, string attributeName)
        {
            string value = GetAttributeValueOrDefault(element, attributeName);
            if (value == null)
                throw CreateException(element, "Element contains no attribute with name " + attributeName);
            return value;
        }

        public static string GetElementValueOrDefault(XElement parent, string elementName)
        {
            XElement element = parent.Element(elementName);
            if (element == null) return null;
            return element.Value;
        }

        public static string GetAttributeValueOrDefault(XElement element, string attributeName)
        {
            XAttribute attr = element.Attribute(attributeName);
            if (attr == null) return null;
            return attr.Value;
        }
    }
}
