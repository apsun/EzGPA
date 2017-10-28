using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;
using System.Xml.Linq;
using EzGPA.Core;

namespace EzGPA.Config
{
    /// <summary>
    /// Handles the creation of course templates from XML elements.
    /// </summary>
    public class LevelTemplateLoader
    {
        private readonly Dictionary<string, LevelGroup[]> _cache = new Dictionary<string, LevelGroup[]>();
        private readonly Dictionary<string, LevelGroup[]> _templates;

        /// <summary>
        /// Creates a new template loader from an XML element.
        /// </summary>
        /// <param name="templateElements">The element that contains the level templates.</param>
        public LevelTemplateLoader(XElement templateElements)
        {
            try
            {
                _templates = Parse(templateElements);
            }
            catch (XmlException ex)
            {
                throw new ConfigLoadException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Combines multiple templates into a single level group.
        /// </summary>
        /// <param name="templateNames">The comma-delimited string of template names.</param>
        public LevelGroup[] Build(string templateNames)
        {
            // First check if the group has already been built
            LevelGroup[] combinedGroups;
            if (_templates.TryGetValue(templateNames, out combinedGroups))
                return combinedGroups;
            if (_cache.TryGetValue(templateNames, out combinedGroups))
                return combinedGroups;

            // This list exists to preserve the order of groups. 
            // An ordered dictionary would work too, but this is easier.
            var groupNames = new List<string>();
            var groupMap = new Dictionary<string, List<Level>>();
            var defaultGroup = new List<Level>();
            string[] splitTemplateNames = templateNames.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string templateName in splitTemplateNames)
            {
                // Get the template that we're building off of
                LevelGroup[] groups;
                if (!_templates.TryGetValue(templateName, out groups))
                    throw new ConfigLoadException("Attempting to use undefined level template: " + templateName);

                foreach (LevelGroup group in groups)
                {
                    string groupName = group.Name;
                    if (groupName == null)
                    {
                        defaultGroup.AddRange(group);
                    }
                    else
                    {
                        List<Level> levels;

                        // Check if the group already exists.
                        // If so, just keep appending to that group, 
                        // otherwise, create a new group.
                        if (!groupMap.TryGetValue(groupName, out levels))
                        {
                            levels = new List<Level>();
                            groupMap.Add(groupName, levels);
                            groupNames.Add(groupName);
                        }

                        // We won't check for duplicate levels here, 
                        // since it adds too much complexity and isn't 
                        // really that large of an issue anyways.
                        levels.AddRange(group);
                    }
                }
            }

            // Make sure we're not combining templates with and without groups
            if (defaultGroup.Count > 0 && groupNames.Count > 0)
                throw new ConfigLoadException("Cannot combine templates unless either all or none have groups");

            if (defaultGroup.Count > 0)
            {
                // All templates have no groups
                combinedGroups = new[] { new LevelGroup(null, defaultGroup.ToArray()) };
            }
            else
            {
                // All templates have groups
                // Convert each level list to a LevelGroup object
                combinedGroups = new LevelGroup[groupNames.Count];
                for (int i = 0; i < combinedGroups.Length; ++i)
                {
                    string groupName = groupNames[i];
                    Level[] groupLevels = groupMap[groupName].ToArray();
                    combinedGroups[i] = new LevelGroup(groupName, groupLevels);
                }
            }

            // Add the group to the cache for faster future processing
            _cache.Add(templateNames, combinedGroups);
            return combinedGroups;
        }

        private static Dictionary<string, LevelGroup[]> Parse(XElement templateElements)
        {
            var templates = new Dictionary<string, LevelGroup[]>();
            foreach (XElement templateElement in templateElements.Elements("template"))
            {
                string templateName = XmlHelper.GetAttributeValue(templateElement, "name");
                if (templates.ContainsKey(templateName))
                    throw XmlHelper.CreateException(templateElement, "Duplicate level template: " + templateName);
                Debug.WriteLine("Loading level template: " + templateName);
                templates.Add(templateName, LoadGroups(templateElement));
            }
            return templates;
        }

        private static LevelGroup[] LoadGroups(XElement templateElement)
        {
            // Handle grouped levels
            var seenGroupNames = new HashSet<string>();
            var groupList = new List<LevelGroup>();
            foreach (XElement groupElement in templateElement.Elements("group"))
            {
                string groupName = XmlHelper.GetAttributeValue(groupElement, "name");
                if (!seenGroupNames.Add(groupName))
                    throw XmlHelper.CreateException(groupElement, "Duplicate group name: " + groupName);
                Debug.WriteLine("> Loading group: " + groupName);
                groupList.Add(new LevelGroup(groupName, LoadLevels(groupElement)));
            }

            // Handle ungrouped levels
            Debug.WriteLine("> Loading default group: ");
            Level[] defaultGroup = LoadLevels(templateElement);

            // Make sure we don't have both grouped and ungrouped levels
            if (defaultGroup.Length > 0 && groupList.Count > 0)
                throw XmlHelper.CreateException(templateElement,
                    "Cannot partially group levels; either all or none must be grouped");

            // We only have ungrouped levels
            if (defaultGroup.Length > 0)
                return new[] { new LevelGroup(null, defaultGroup) };

            // We only have grouped levels
            return groupList.ToArray();
        }

        private static Level[] LoadLevels(XElement groupElement)
        {
            var seenLevelNames = new HashSet<string>();
            var levelList = new List<Level>();
            foreach (XElement levelElement in groupElement.Elements("level"))
            {
                string levelName = XmlHelper.GetAttributeValue(levelElement, "name");
                if (!seenLevelNames.Add(levelName))
                    throw XmlHelper.CreateException(levelElement, "Duplicate level name: " + levelName);
                Debug.WriteLine(">> Loading level: " + levelName);
                string bonusGpaStr = XmlHelper.GetAttributeValue(levelElement, "bonusgpa");
                double bonusGpa;
                if (!StringParser.TryParseDoubleStrict(bonusGpaStr, out bonusGpa) || bonusGpa < 0)
                    throw XmlHelper.CreateException(levelElement, "Invalid bonus GPA value: " + bonusGpaStr);
                levelList.Add(new Level(levelName, bonusGpa));
            }
            return levelList.ToArray();
        }
    }
}
