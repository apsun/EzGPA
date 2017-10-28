using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EzGPA.Localization
{
    public class StringFormatter : IFormatProvider, ICustomFormatter
    {
        private readonly Dictionary<string, SwitchTable> _switchTables;
        private readonly object[] _args;
        private readonly HashSet<string> _seenSwitchTableNames;

        public StringFormatter(Dictionary<string, SwitchTable> switchTables, object[] args)
        {
            _switchTables = switchTables;
            _args = args;
            _seenSwitchTableNames = new HashSet<string>();
        }

        public object GetFormat(Type formatType)
        {
            return (formatType == typeof (ICustomFormatter)) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            LookupToken lookupToken = arg as LookupToken;

            // Linking to another localized string
            if (lookupToken != null)
            {
                // Using {0} directly is prohibited
                if (format == null)
                    throw new FormatException("Cannot use {0} directly; you must specify another string");
                try
                {
                    string str = lookupToken.GetLocalizedString(format);
                    Debug.WriteLine("Linking to localized string: " + format);
                    return str;
                }
                catch (KeyNotFoundException ex)
                {
                    throw new FormatException("Linking to undefined string: " + format, ex);
                }
            }

            // Using a switch table
            if (format == null)
                return arg.ToString();
            SwitchTable table;
            if (!_switchTables.TryGetValue(format, out table))
                throw new FormatException("Attempting to use undefined switch table: " + format);
            if (_seenSwitchTableNames.Add(format))
                throw new FormatException("Recursive switch table definition: " + format);
            Debug.WriteLine(string.Format("Looking up value in switch table: {0} > {1}", format, arg));
            return string.Format(this, table[arg.ToString()], _args);
        }
    }
}
