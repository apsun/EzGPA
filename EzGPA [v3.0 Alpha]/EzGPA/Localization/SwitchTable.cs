using System;
using System.Collections.Generic;

namespace EzGPA.Localization
{
    public class SwitchTable
    {
        private readonly Dictionary<string, string> _table;
        private readonly string _defaultValue;

        public SwitchTable(Dictionary<string, string> table, string defaultValue)
        {
            _table = table;
            _defaultValue = defaultValue;
        }

        public string this[string key]
        {
            get
            {
                string value;
                if (_table.TryGetValue(key, out value)) return value;
                if (_defaultValue != null) return _defaultValue;
                throw new FormatException("Could not find switch case for key " + key);
            }
        }
    }
}
