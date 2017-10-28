using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using EzGPA.Core;

namespace EzGPA.Config
{
    public class CourseLoader
    {
        private School _school;

        public CourseLoader(TemplateLoader templateLoader, XElement courseElements)
        {
            try
            {
                _school = Parse(templateLoader, courseElements);
            }
            catch (XmlException ex)
            {
                throw new ConfigLoadException(ex.Message, ex);
            }
        }

        private static School Parse(TemplateLoader templateLoader, XElement courseElements)
        {
            List<Grade> grades = new List<Grade>();
            foreach (XElement gradeElement in courseElements.Elements("grade"))
            {
                string gradeIdStr = XmlHelper.GetAttributeValue(gradeElement, "id");
                string gradeName = XmlHelper.GetAttributeValue(gradeElement, "name");
                Debug.WriteLine(string.Format("Loading grade {0} ({1})", gradeName, gradeIdStr));
                Guid gradeId;
                if (!StringParser.TryParseGuid(gradeIdStr, out gradeId))
                    throw XmlHelper.CreateException(gradeElement, "Invalid grade ID: " + gradeIdStr);
                grades.Add(new Grade(gradeId, gradeName, LoadCourses(templateLoader, gradeElement)));
            }
            return new School(grades.ToArray());
        }

        private static Course[] LoadCourses(TemplateLoader templateLoader, XElement gradeElement)
        {
            List<Course> courses = new List<Course>();
            foreach (XElement courseElement in gradeElement.Elements())
            {
                switch (gradeElement.Name.ToString())
                {
                    case "course":
                        courses.Add(LoadSingleCourse(templateLoader, courseElement));
                        break;
                    case "multicourse":
                        courses.Add(LoadMultiCourse(courses, templateLoader, courseElement));
                        break;
                }
            }
            return courses.ToArray();
        }

        private static DynamicCourse LoadMultiCourse(List<Course> courses, TemplateLoader templateLoader, 
            XElement courseElement)
        {
            string linkName = XmlHelper.GetAttributeValueOrDefault(courseElement, "link");
            
            if (linkName == null)
                return LoadMultiCourseNoLink(templateLoader, courseElement);
            
            DynamicCourse linkedCourse = courses.FirstOrDefault(c => c.Name == linkName) as DynamicCourse;
            if (linkedCourse == null)
                throw XmlHelper.CreateException(courseElement, "Invalid course link: " + linkName);
            return LoadMultiCourseWithLink(linkedCourse, courseElement);
        }
        
        private static DynamicCourse LoadMultiCourseNoLink(TemplateLoader templateLoader, XElement courseElement)
        {
            string courseName = XmlHelper.GetAttributeValue(courseElement, "name");
            string scoreTemplate = XmlHelper.GetAttributeValue(courseElement, "scores");
            string courseTemplatesStr = XmlHelper.GetAttributeValue(courseElement, "levels");
            string creditsStr = XmlHelper.GetAttributeValue(courseElement, "credits");
            StaticCourse[] subCourses = courseElement
                .Elements("course")
                .Select(subCourseElement => 
                    LoadCourse(templateLoader, courseElement, scoreTemplate, courseTemplatesStr, creditsStr))
                .ToArray();
            return new DynamicCourse(courseName, subCourses);
        }
        
        private static DynamicCourse LoadMultiCourseWithLink(DynamicCourse linkedCourse, XElement courseElement)
        {
            // Make sure no attributes other than link and name are defined
            string courseName = XmlHelper.GetAttributeValue(courseElement, "name");
            if (courseElement.Attribute("scores") != null)
                throw XmlHelper.CreateException(courseElement, "Cannot define score for linked course");
            if (courseElement.Attribute("levels") != null)
                throw XmlHelper.CreateException(courseElement, "Cannot define levels for linked course");
            if (courseElement.Attribute("credits") != null)
                throw XmlHelper.CreateException(courseElement, "Cannot define credits for linked course");
            return new DynamicCourse(courseName, linkedCourse);
        }

        private static StaticCourse LoadSingleCourse(TemplateLoader templateLoader, XElement courseElement)
        {
            return LoadCourse(templateLoader, courseElement, null, null, null);
        }

        private static StaticCourse LoadCourse(TemplateLoader templateLoader, XElement courseElement,
            string parentScoreTemplate, string parentLevelTemplates, string parentCreditsStr)
        {
            string courseName = XmlHelper.GetAttributeValue(courseElement, "name");

            string scoreTemplate = XmlHelper.GetAttributeValue(courseElement, "scores") ?? parentScoreTemplate;
            if (scoreTemplate == null)
                throw XmlHelper.CreateException(courseElement, "Unspecified score template");

            string courseTemplates = XmlHelper.GetAttributeValue(courseElement, "levels") ?? parentLevelTemplates;
            if (courseTemplates == null)
                throw XmlHelper.CreateException(courseElement, "Unspecified level template");

            string creditsStr = XmlHelper.GetAttributeValue(courseElement, "credits") ?? parentCreditsStr;
            if (creditsStr == null)
                throw XmlHelper.CreateException(courseElement, "Unspecified credits value");

            double credits;
            if (!StringParser.TryParseDoubleStrict(creditsStr, out credits) || credits < 0)
                throw XmlHelper.CreateException(courseElement, "Invalid credits value: " + creditsStr);

            LevelGroup[] groups = templateLoader.BuildLevels(courseTemplates);
            ScoreTable scoreTable = templateLoader.BuildScoreTable(scoreTemplate);
            return new StaticCourse(courseName, credits, groups, scoreTable);
        }
    }
}
