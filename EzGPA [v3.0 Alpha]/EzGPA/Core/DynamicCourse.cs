using System;
using System.Collections.Generic;
using System.Linq;

namespace EzGPA.Core
{
    /// <summary>
    /// Represents a course that can differ between students (typically an elective course).
    /// </summary>
    public class DynamicCourse : Course
    {
        private readonly string _name;
        private readonly StaticCourse[] _courses;
        private StaticCourse _selectedCourse;
        private DynamicCourse _linkedHead;
        private List<DynamicCourse> _linkedChildren;

        public IEnumerable<StaticCourse> Courses
        {
            // Return courses as read-only 
            get { return _courses.Skip(0); }
        }

        /// <summary>
        /// Gets the name of the course container itself. 
        /// This should not be visible to the user, since 
        /// each sub-course has its own name.
        /// </summary>
        public override string RawName
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the localized name of the course.
        /// </summary>
        public override string Name
        {
            get { return SelectedCourse.Name; }
        }

        /// <summary>
        /// Gets the credit value of the course.
        /// </summary>
        public override double Credits
        {
            get { return SelectedCourse.Credits; }
        }

        /// <summary>
        /// Gets the number of logical level "groups" for the course. Returns 0 
        /// if there are no levels or if the only group is the default group.
        /// </summary>
        public override int GroupCount
        {
            get { return SelectedCourse.GroupCount; }
        }

        /// <summary>
        /// Gets the score table used to calculate the course GPA.
        /// </summary>
        public override ScoreTable ScoreTable
        {
            get { return SelectedCourse.ScoreTable; }
        }

        /// <summary>
        /// Gets or sets the selected level group of the course.
        /// </summary>
        public override LevelGroup SelectedLevelGroup
        {
            get { return SelectedCourse.SelectedLevelGroup; }
            set { SelectedCourse.SelectedLevelGroup = value; }
        }

        /// <summary>
        /// Gets or sets the selected level of the course. This 
        /// level must be in currently selected group.
        /// </summary>
        public override Level SelectedLevel
        {
            get { return SelectedCourse.SelectedLevel; }
            set { SelectedCourse.SelectedLevel = value; }
        }

        /// <summary>
        /// Gets the GPA value for this course.
        /// </summary>
        public override double Gpa
        {
            get { return SelectedCourse.Gpa; }
        }

        /// <summary>
        /// Gets or sets the underlying course object that is used to 
        /// calculate the GPA of this course.
        /// </summary>
        public StaticCourse SelectedCourse
        {
            get { return _selectedCourse; }
            set
            {
                if (_selectedCourse == value)
                    return;
                if (value == null)
                    throw new ArgumentNullException("value");
                if (!_courses.Contains(value))
                    throw new InvalidOperationException("Course does not belong to this object");
                _selectedCourse = value;
                if (_linkedHead != null)
                {
                    foreach (DynamicCourse course in _linkedHead._linkedChildren)
                    {
                        if (course != this && course._selectedCourse == value)
                        {
                            course._selectedCourse = course.GetNextCourseChoice();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Constructs a new dynamic course object.
        /// </summary>
        /// <param name="name">The name of the course container.</param>
        /// <param name="courses">An array containing the underlying course objects.</param>
        public DynamicCourse(string name, StaticCourse[] courses)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (courses == null)
                throw new ArgumentNullException("courses");
            if (courses.Length == 0)
                throw new ArgumentException("Must provide at least one course object");
            _name = name;
            _courses = courses;
            _selectedCourse = courses[0];
        }

        /// <summary>
        /// Constructs a new dynamic course object and links it to an existing dynamic course.
        /// </summary>
        /// <param name="name">The name of the course container.</param>
        /// <param name="linkedCourse">An existing dynamic course object to link to.</param>
        public DynamicCourse(string name, DynamicCourse linkedCourse)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (linkedCourse == null)
                throw new ArgumentNullException("linkedCourse");
            _name = name;
            _courses = linkedCourse._courses;
            DynamicCourse head = linkedCourse;
            if (head._linkedHead != null)
            {
                // Course is already linked to another course
                // Get the actual root of the link chain
                head = head._linkedHead;
                if (head._linkedChildren.Count >= _courses.Length)
                    throw new InvalidOperationException("More linked courses than course options");
            }
            else
            {
                // Course is standalone
                // Let head know it's the root of a chain now
                head._linkedHead = head;
                head._linkedChildren = new List<DynamicCourse>();
            }
            head._linkedChildren.Add(this);
            _linkedHead = head;
            _selectedCourse = GetNextCourseChoice();
        }


        private StaticCourse GetNextCourseChoice()
        {
            HashSet<StaticCourse> selectedCourses = new HashSet<StaticCourse>();
            foreach (DynamicCourse course in _linkedHead._linkedChildren)
                selectedCourses.Add(course.SelectedCourse);
            return _courses.First(course => !selectedCourses.Contains(course));
        }

        public override IEnumerator<LevelGroup> GetEnumerator()
        {
            return SelectedCourse.GetEnumerator();
        }
    }
}
