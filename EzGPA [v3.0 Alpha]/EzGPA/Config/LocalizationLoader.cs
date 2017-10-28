using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;
using EzGPA.Localization;

namespace EzGPA.Config
{
    public class LocalizationLoader
    {
        private readonly Dictionary<LocaleInfo, LocalizationManager> _locales;

        public ICollection<LocaleInfo> Locales
        {
            get { return _locales.Keys; }
        }

        public LocalizationManager this[LocaleInfo locale]
        {
            get { return _locales[locale]; }
        }

        public LocalizationLoader(XElement localeElements)
        {
            _locales = LoadLocales(localeElements);
        }

        private static Dictionary<LocaleInfo, LocalizationManager> LoadLocales(XElement localeElements)
        {
            var locales = new Dictionary<LocaleInfo, LocalizationManager>();
            foreach (XElement localeElement in localeElements.Elements("locale"))
            {
                string localeId = XmlHelper.GetAttributeValue(localeElement, "id");
                string localeName = XmlHelper.GetAttributeValue(localeElement, "name");
                LocaleInfo localeInfo = new LocaleInfo(localeId, localeName);

                // Ensure locale ID is unique
                if (locales.ContainsKey(localeInfo))
                    throw XmlHelper.CreateException(localeElement, "Duplicate definition of locale: " + localeInfo);

                Debug.WriteLine("Loading locale: " + localeInfo);
                Dictionary<string, LocalizedString> localizedStrings = LoadSingleLocale(localeElement);
                LocalizationManager locale = new LocalizationManager(localizedStrings);
                locales.Add(localeInfo, locale);
            }

            return locales;
        }

        private static Dictionary<string, LocalizedString> LoadSingleLocale(XElement localeElement)
        {
            var localizedStrings = new Dictionary<string, LocalizedString>();
            foreach (XElement stringElement in localeElement.Elements())
            {
                string stringName = stringElement.Name.ToString();

                // Check for duplicate localized string definition
                if (localizedStrings.ContainsKey(stringName))
                    throw XmlHelper.CreateException(stringElement,
                        "Duplicate definition of localized string: " + stringName);

                Debug.WriteLine("> Loading localized string: " + stringName);
                string stringValue = LoadStringValue(stringElement);
                Dictionary<string, SwitchTable> switchTables = LoadSwitchTables(stringElement);
                LocalizedString localizedString = new LocalizedString(stringValue, switchTables);
                localizedStrings.Add(stringName, localizedString);
            }

            // Make sure all localized strings have been defined
            foreach (string expectedString in Enum.GetNames(typeof (LocalizationManager.LocalizedStrings)))
            {
                if (!localizedStrings.ContainsKey(expectedString))
                    throw new ConfigLoadException("Undefined localized string: " + expectedString);
            }

            return localizedStrings;
        }

        private static Dictionary<string, SwitchTable> LoadSwitchTables(XElement stringElement)
        {
            var tables = new Dictionary<string, SwitchTable>();
            foreach (XElement switchElement in stringElement.Elements("switch"))
            {
                string switchName = XmlHelper.GetAttributeValue(switchElement, "name");

                // Make sure the table hasn't been defined already
                if (tables.ContainsKey(switchName))
                    throw XmlHelper.CreateException(switchElement,
                        "Duplicate definition of switch table: " + switchName);

                Debug.WriteLine(">> Loading switch table: " + switchName);

                // Get the switch cases
                Dictionary<string, string> switchValues = new Dictionary<string, string>();
                foreach (XElement caseElement in switchElement.Elements("case"))
                {
                    string caseName = XmlHelper.GetAttributeValue(caseElement, "key");

                    // Check for duplicate case definition
                    if (switchValues.ContainsKey(caseName))
                        throw XmlHelper.CreateException(caseElement,
                            "Duplicate definition of switch case: " + caseName);

                    switchValues.Add(caseName, caseElement.Value);
                }

                // Get the default value for when a value doesn't match any case
                string defaultCase = XmlHelper.GetAttributeValueOrDefault(switchElement, "default");

                tables.Add(switchName, new SwitchTable(switchValues, defaultCase));
            }

            return tables;
        }

        private static string LoadStringValue(XElement stringElement)
        {
            StringBuilder valueBuilder = null;

            // Use a <value> element if it exists, otherwise use 
            // the contents of the string directly.
            XElement textElement = stringElement.Element("value") ?? stringElement;
            bool sawLine = false;

            // If a <line> element has been defined, concatenate 
            // them, otherwise use the value in the element directly.
            foreach (XElement line in textElement.Elements("line"))
            {
                if (!sawLine)
                {
                    sawLine = true;
                    valueBuilder = new StringBuilder();
                }
                else
                {
                    valueBuilder.AppendLine();
                }

                valueBuilder.Append(line.Value);
            }

            return sawLine ? valueBuilder.ToString() : textElement.Value;
        }
    }
}
