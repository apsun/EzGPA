using System;
using System.Collections;
using System.Collections.Generic;

namespace EzGPA.Core
{
    /// <summary>
    /// Represents a school grade, encapsulating multiple courses.
    /// </summary>
    public class Grade : IEnumerable<Course>
    {
        private readonly Guid _id;
        private readonly string _name;
        private readonly Course[] _courses;

        /// <summary>
        /// Gets the globally unique ID of the grade.
        /// </summary>
        public Guid Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Gets the untranslated name of the grade.
        /// </summary>
        public string RawName
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the name of the grade.
        /// </summary>
        public string Name
        {
            get { return NameTranslator(_name); }
        }

        /// <summary>
        /// Gets the number of courses in the grade.
        /// </summary>
        public int CourseCount
        {
            get { return _courses.Length; }
        }

        /// <summary>
        /// Gets or sets the function responsible for 
        /// translating the name of the grade.
        /// </summary>
        public StringTranslator NameTranslator { get; set; }

        /// <summary>
        /// Gets the overall GPA for the grade.
        /// </summary>
        public double Gpa
        {
            get
            {
                double creditSum = 0;
                double gpaSum = 0;
                foreach (Course course in _courses)
                {
                    gpaSum += course.Gpa * course.Credits;
                    creditSum += course.Credits;
                }
                return gpaSum / creditSum;
            }
        }

        /// <summary>
        /// Constructs a new grade object.
        /// </summary>
        /// <param name="id">The globally unique ID of the grade.</param>
        /// <param name="name">The name of the grade.</param>
        /// <param name="courses">An array of available courses in the grade.</param>
        public Grade(Guid id, string name, Course[] courses)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (courses == null)
                throw new ArgumentNullException("courses");
            _id = id;
            _name = name;
            _courses = courses;

            NameTranslator = x => x;
        }

        IEnumerator<Course> IEnumerable<Course>.GetEnumerator()
        {
            return ((IEnumerable<Course>)_courses).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _courses.GetEnumerator();
        }
    }
}
