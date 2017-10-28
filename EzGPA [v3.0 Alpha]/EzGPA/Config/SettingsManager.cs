using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using EzGPA.Core;

namespace EzGPA.Config
{
    public class SettingsManager
    {
        public bool AutoClear { get; set; }
        public bool AutoCopy { get; set; }
        public string LanguageId { get; set; }

        public SettingsManager()
        {
            AutoClear = true;
            AutoCopy = false;
            LanguageId = CultureInfo.CurrentCulture.Name;
        }

        private static void TryLoadOption<T>(XElement configRoot, string elementName, 
            StringParser.TryParseFunc<T> parser, Action<T> setter)
        {
            T value;
            string strValue = XmlHelper.GetElementValueOrDefault(configRoot, elementName);
            if (parser(strValue, out value)) setter(value);
        }

        private static void TryLoadBool(XElement configRoot, string elementName, Action<bool> setter)
        {
            TryLoadOption(configRoot, elementName, bool.TryParse, setter);
        }

        private static void TryLoadString(XElement configRoot, string elementName, Action<string> setter)
        {
            string strValue = XmlHelper.GetElementValueOrDefault(configRoot, elementName);
            if (strValue != null) setter(strValue);
        }

        private static void LoadCourseConfig(XElement configRoot, School school)
        {
            XElement coursesElement = configRoot.Element("courses");
            if (coursesElement == null) return;

            foreach (Grade grade in school)
            {
                foreach (XElement gradeElement in coursesElement.Elements("grade"))
                {
                    XAttribute idAttr = gradeElement.Attribute("id");
                    if (idAttr == null) continue;
                    Guid configGradeId;
                    if (!StringParser.TryParseGuid(idAttr.Value, out configGradeId)) continue;
                    if (configGradeId != grade.Id) continue;
                    LoadGrade(gradeElement, grade);
                }
            }
            string activeGradeIdStr = XmlHelper.GetElementValueOrDefault(configRoot, "active");
            Guid activeGradeId;
            if (StringParser.TryParseGuid(activeGradeIdStr, out activeGradeId))
                school.SelectedGrade = school.First(g => g.Id == activeGradeId);
        }

        private static void LoadGrade(XElement gradeConfigElement, Grade grade)
        {
            foreach (Course course in grade)
            {
                foreach (XElement courseElement in gradeConfigElement.Elements("course"))
                {
                    XAttribute idAttr = courseElement.Attribute("name");
                    if (idAttr == null) continue;
                    if (idAttr.Value != course.Name) continue;
                    LoadCourse(courseElement, course);
                }
            }
        }

        private static void LoadCourse(XElement courseConfigElement, Course course)
        {
            // Sub-course
            DynamicCourse dynamicCourse = course as DynamicCourse;
            if (dynamicCourse != null)
            {
                string selectedCourseStr = XmlHelper.GetElementValueOrDefault(courseConfigElement, "selected");
                if (selectedCourseStr != null)
                {
                    StaticCourse selected = dynamicCourse.Courses.FirstOrDefault(c => c.RawName == selectedCourseStr);
                    if (selected != null) dynamicCourse.SelectedCourse = selected;
                }
            }

            // Enabled
            string enabledStr = XmlHelper.GetElementValueOrDefault(courseConfigElement, "enabled");
            bool enabled;
            if (bool.TryParse(enabledStr, out enabled))
                course.Enabled = enabled;

            // Group
            if (course.GroupCount > 0)
            {
                string groupStr = XmlHelper.GetElementValueOrDefault(courseConfigElement, "group");
                if (groupStr != null)
                {
                    LevelGroup group = course.FirstOrDefault(g => g.RawName == groupStr);
                    if (group != null) course.SelectedLevelGroup = group;
                }
            }

            // Level
            if (course.SelectedLevelGroup.LevelCount > 0)
            {
                string levelStr = XmlHelper.GetElementValueOrDefault(courseConfigElement, "level");
                if (levelStr != null)
                {
                    Level level = course.SelectedLevelGroup.FirstOrDefault(l => l.RawName == levelStr);
                    if (level != null) course.SelectedLevel = level;
                }
            }

            // Score
            string scoreStr = XmlHelper.GetElementValueOrDefault(courseConfigElement, "score");
            if (scoreStr != null)
                course.Score = scoreStr;
        }

        private static void SaveCourseConfig(XElement configRoot, School school)
        {
            configRoot.SetElementValue("courses", 
                school.Select(g => new XElement("grade",
                    new XAttribute("id", g.Id),
                    g.Select(c => new XElement("course",
                        new XAttribute("name", c.RawName),
                        new XElement("enabled", c.Enabled),
                        c.GroupCount > 0 ? new XElement("group", c.SelectedLevelGroup.RawName) : null,
                        c.SelectedLevelGroup.LevelCount > 0 ? new XElement("level", c.SelectedLevel.RawName) : null,
                        c is DynamicCourse ? new XElement("selected", ((DynamicCourse)c).SelectedCourse.RawName) : null,
                        new XElement("score", c.Score))))));
        }

        public void Load(XElement configRoot, School school)
        {
            TryLoadBool(configRoot, "autoClear", x => AutoClear = x);
            TryLoadBool(configRoot, "autoCopy", x => AutoCopy = x);
            TryLoadString(configRoot, "locale", x => LanguageId = x);
            LoadCourseConfig(configRoot, school);
        }

        public void Save(XElement configRoot, School school)
        {
            configRoot.SetElementValue("autoClear", AutoClear);
            configRoot.SetElementValue("autoCopy", AutoCopy);
            configRoot.SetElementValue("locale", LanguageId);
            SaveCourseConfig(configRoot, school);
        }
    }
}
