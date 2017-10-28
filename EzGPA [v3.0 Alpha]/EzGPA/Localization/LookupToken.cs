using System;
using System.Collections.Generic;

namespace EzGPA.Localization
{
    internal class LookupToken
    {
        private readonly LocalizationManager _container;
        private readonly HashSet<string> _seenStringNames;

        public LookupToken(LocalizationManager container)
        {
            _container = container;
            _seenStringNames = new HashSet<string>();
        }

        public void MarkString(string key)
        {
            if (!_seenStringNames.Add(key))
                throw new FormatException("Recursive string definition: " + key);
        }

        public string GetLocalizedString(string key)
        {
            return _container.GetLocalizedString(this, key, this);
        }
    }
}
