using System;
using System.Linq;
using System.Collections.Generic;

namespace EzGPA.Core
{
    /// <summary>
    /// Represents a course that is common for all students (typically a compulsory course).
    /// </summary>
    public class StaticCourse : Course
    {
        private readonly string _name;
        private readonly double _credits;
        private readonly LevelGroup[] _groups;
        private readonly ScoreTable _scoreTable;
        private LevelGroup _selectedLevelGroup;
        private Level _selectedLevel;

        /// <summary>
        /// Gets the untranslated name of the course.
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
            get { return NameTranslator(_name); }
        }

        /// <summary>
        /// Gets the credit value of the course.
        /// </summary>
        public override double Credits
        {
            get { return _credits; }
        }

        /// <summary>
        /// Gets the number of logical level "groups" for the course. Returns 0 
        /// if there are no levels or if the only group is the default group.
        /// </summary>
        public override int GroupCount
        {
            get
            {
                if (_groups.Length == 1 && _groups[0].IsDefaultGroup) return 0;
                return _groups.Length;
            }
        }

        /// <summary>
        /// Gets the score table used to calculate the course GPA.
        /// </summary>
        public override ScoreTable ScoreTable
        {
            get { return _scoreTable; }
        }

        /// <summary>
        /// Gets or sets the selected level group of the course.
        /// </summary>
        public override LevelGroup SelectedLevelGroup
        {
            get { return _selectedLevelGroup; }
            set
            {
                if (_selectedLevelGroup == value)
                    return;
                if (value == null)
                    throw new ArgumentNullException("value");
                if (!_groups.Contains(value))
                    throw new InvalidOperationException("Level group does not belong to this object");
                _selectedLevelGroup = value;
                _selectedLevel = value.LevelCount > 0 ? value[0] : null;
            }
        }

        /// <summary>
        /// Gets or sets the selected level of the course. This 
        /// level must be in currently selected group.
        /// </summary>
        public override Level SelectedLevel
        {
            get { return _selectedLevel; }
            set
            {
                if (_selectedLevel == value)
                    return;
                if (value == null && SelectedLevelGroup.LevelCount > 0)
                    throw new ArgumentException("Level cannot be null if more than one level is available");
                if (value != null && !SelectedLevelGroup.Contains(value))
                    throw new InvalidOperationException("Level does not belong to the currently selected group");
                _selectedLevel = value;
            }
        }

        /// <summary>
        /// Gets the GPA value for this course.
        /// </summary>
        public override double Gpa
        {
            get
            {
                double bonusGpa = SelectedLevel == null ? 0 : SelectedLevel.BonusGpa;
                return _scoreTable.GetGpa(Score, bonusGpa);
            }
        }

        /// <summary>
        /// Gets or sets the function responsible for 
        /// translating the name of the course.
        /// </summary>
        public StringTranslator NameTranslator { get; set; }

        /// <summary>
        /// Constructs a new course object.
        /// </summary>
        /// <param name="name">The name of the course.</param>
        /// <param name="credits">The credit value of the course.</param>
        /// <param name="groups">An array containing the level groups of the course.</param>
        /// <param name="scoreTable">The table that maps scores to GPA values.</param>
        public StaticCourse(string name, double credits, LevelGroup[] groups, ScoreTable scoreTable)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (credits <= 0)
                throw new ArgumentOutOfRangeException("credits");
            if (groups == null)
                throw new ArgumentNullException("groups");
            if (groups.Length == 0)
                throw new ArgumentException("Must provide at least one level group");
            if (scoreTable == null)
                throw new ArgumentNullException("scoreTable");
            _name = name;
            _credits = credits;
            _groups = groups;
            _scoreTable = scoreTable;

            LevelGroup group = groups[0];
            _selectedLevelGroup = group;
            _selectedLevel = group.LevelCount > 0 ? group[0] : null;

            NameTranslator = x => x;
        }

        public override IEnumerator<LevelGroup> GetEnumerator()
        {
            return ((IEnumerable<LevelGroup>)_groups).GetEnumerator();
        }
    }
}
