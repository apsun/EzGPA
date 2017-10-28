using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using EzGPA.Core;

namespace EzGPA.Config
{
    /// <summary>
    /// Handles the creation of score-to-GPA tables from XML elements.
    /// </summary>
    public class ScoreTableLoader
    {
        private readonly Dictionary<string, ScoreTable> _tables;

        /// <summary>
        /// Gets the score table with the specified name.
        /// </summary>
        /// <param name="tableName">The name of the score table.</param>
        public ScoreTable this[string tableName]
        {
            get
            {
                if (!_tables.ContainsKey(tableName))
                    throw new ConfigLoadException("Attempting to use undefined score table: " + tableName);
                return _tables[tableName];
            }
        }

        /// <summary>
        /// Creates a new score table loader from an XML element.
        /// </summary>
        /// <param name="tableElements">The element that contains the score tables.</param>
        public ScoreTableLoader(XElement tableElements)
        {
            try
            {
                _tables = Parse(tableElements);
            }
            catch (XmlException ex)
            {
                throw new ConfigLoadException(ex.Message, ex);
            }
        }

        private static Dictionary<string, ScoreTable> Parse(XElement tableElements)
        {
            var tables = new Dictionary<string, ScoreTable>();
            foreach (XElement tableElement in tableElements.Elements("template"))
            {
                string tableName = XmlHelper.GetAttributeValue(tableElement, "name");
                if (tables.ContainsKey(tableName))
                    throw XmlHelper.CreateException(tableElement, "Duplicate score table: " + tableName);
                Debug.WriteLine("Loading score table: " + tableName);
                TableEntry[] tableEntries = GetTableEntries(tableElement);
                ScoreInputType inputMethod = GetInputMethod(tableElement);
                tables.Add(tableName, new ScoreTable(tableEntries, inputMethod));
            }
            return tables;
        }

        private static TableEntry[] GetTableEntries(XElement tableElement)
        {
            string parserType = XmlHelper.GetAttributeValue(tableElement, "type");
            var scoreCases = new List<TableEntry>();
            foreach (XElement caseElement in tableElement.Elements())
            {
                switch (parserType)
                {
                    case "int":
                        scoreCases.Add(HandleIntType(caseElement));
                        break;
                    case "string":
                        scoreCases.Add(HandleStringType(caseElement));
                        break;
                    default:
                        throw XmlHelper.CreateException(tableElement, "Invalid score case type: " + parserType);
                }
            }

            TableEntry[] entries = scoreCases.ToArray();
            if (entries.Length == 0)
                throw XmlHelper.CreateException(tableElement, "No table entries specified");
            return entries;
        }

        private static ScoreInputType GetInputMethod(XElement tableElement)
        {
            string controlType = XmlHelper.GetAttributeValue(tableElement, "control");
            switch (controlType)
            {
                case "textbox":
                    return ScoreInputType.Free;
                case "combobox":
                    return ScoreInputType.Select;
                default:
                    throw XmlHelper.CreateException(tableElement, "Invalid control type: " + controlType);
            }
        }

        private static double GetBaseGpa(XElement caseElement)
        {
            double gpa;
            string gpaStr = XmlHelper.GetAttributeValue(caseElement, "basegpa");
            if (!StringParser.TryParseDoubleStrict(gpaStr, out gpa) || gpa < 0)
                throw XmlHelper.CreateException(caseElement, "Invalid base GPA value: " + gpaStr);
            Debug.WriteLine(">> GPA: " + gpa);
            return gpa;
        }

        private static bool GetBonusStatus(XElement caseElement)
        {
            bool bonus;
            string bonusStr = XmlHelper.GetAttributeValueOrDefault(caseElement, "bonus");
            if (bonusStr == null)
                bonus = true;
            else if (!bool.TryParse(bonusStr, out bonus))
                throw XmlHelper.CreateException(caseElement, "Invalid bonus GPA bool value: " + bonusStr);
            Debug.WriteLine(">> Bonus: " + bonus);
            return bonus;
        }

        private static TableEntry HandleIntType(XElement caseElement)
        {
            double gpa = GetBaseGpa(caseElement);
            bool bonus = GetBonusStatus(caseElement);

            if (caseElement.Name == "range")
            {
                int? lower, upper;

                string lowerStr = XmlHelper.GetAttributeValueOrDefault(caseElement, "lower");
                string upperStr = XmlHelper.GetAttributeValueOrDefault(caseElement, "upper");

                if (!StringParser.TryParseIntNullable(lowerStr, out lower))
                    throw XmlHelper.CreateException(caseElement, "Invalid lower score range int value: " + lowerStr);
                if (!StringParser.TryParseIntNullable(upperStr, out upper))
                    throw XmlHelper.CreateException(caseElement, "Invalid upper score range int value: " + upperStr);
                if (lower == null && upper == null)
                    throw XmlHelper.CreateException(caseElement, "Must specify either at least one bound");
                
                IntTableRange range = new IntTableRange(lower, upper, gpa, bonus);
                Debug.WriteLine("> Loading <int> range: " + range);
                return range;
            }

            if (caseElement.Name == "item")
            {
                int value;
                string valueStr = XmlHelper.GetAttributeValue(caseElement, "value");
                if (!int.TryParse(valueStr, out value))
                    throw XmlHelper.CreateException(caseElement, "Invalid score case int value: " + valueStr);
                IntTableItem item = new IntTableItem(value, gpa, bonus);
                Debug.WriteLine("> Loading <int> item: " + item);
                return item;
            }

            throw XmlHelper.CreateException(caseElement, "Invalid score case type: " + caseElement.Name);
        }

        private static TableEntry HandleStringType(XElement caseElement)
        {
            double gpa = GetBaseGpa(caseElement);
            bool bonus = GetBonusStatus(caseElement);

            if (caseElement.Name == "item")
            {
                string value = XmlHelper.GetAttributeValue(caseElement, "value");
                StringTableItem item = new StringTableItem(value, gpa, bonus);
                Debug.WriteLine("> Loading <string> item: " + item);
                return item;
            }

            throw XmlHelper.CreateException(caseElement, "Invalid score case type: " + caseElement.Name);
        }
    }
}
