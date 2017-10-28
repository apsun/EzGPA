using System.Collections;
using System.Collections.Generic;

namespace EzGPA.Core
{
    /// <summary>
    /// Represents a single course with its levels and credit value.
    /// </summary>
    public abstract class Course : IEnumerable<LevelGroup>
    {
        /// <summary>
        /// Gets the untranslated name of the course.
        /// </summary>
        public abstract string RawName { get; }

        /// <summary>
        /// Gets the localized name of the course.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the credit value of the course.
        /// </summary>
        public abstract double Credits { get; }

        /// <summary>
        /// Gets the number of logical level "groups" for the course. Returns 0 
        /// if there are no levels or if the only group is the default group.
        /// </summary>
        public abstract int GroupCount { get; }

        /// <summary>
        /// Gets the score table used to calculate the course GPA.
        /// </summary>
        public abstract ScoreTable ScoreTable { get; }

        /// <summary>
        /// Gets or sets the selected level group of the course.
        /// </summary>
        public abstract LevelGroup SelectedLevelGroup { get; set; }

        /// <summary>
        /// Gets or sets the selected level of the course. This 
        /// level must be in currently selected group.
        /// </summary>
        public abstract Level SelectedLevel { get; set; }

        /// <summary>
        /// Gets or sets the score of the course.
        /// </summary>
        public string Score { get; set; }

        /// <summary>
        /// Gets or sets whether this course should be used to calculate the 
        /// overall GPA.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Gets the GPA value for this course.
        /// </summary>
        public abstract double Gpa { get; }

        public abstract IEnumerator<LevelGroup> GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
