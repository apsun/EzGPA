using System.Collections.Generic;

namespace EzGPA.Localization
{
    public class LocalizedString
    {
        private readonly string _value;
        private readonly Dictionary<string, SwitchTable> _switchTables;

        public LocalizedString(string value, Dictionary<string, SwitchTable> switchTables)
        {
            _value = value;
            _switchTables = switchTables;
        }

        public string Format(params object[] args)
        {
            StringFormatter formatter = new StringFormatter(_switchTables, args);
            return string.Format(formatter, _value, args);
        }
    }
}
