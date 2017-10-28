using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EzGPA.Core
{
    public class School : IEnumerable<Grade>
    {
        private readonly Grade[] _grades;
        private Grade _selectedGrade;

        public int GradeCount
        {
            get { return _grades.Length; }
        }

        public Grade SelectedGrade
        {
            get { return _selectedGrade; }
            set
            {
                if (_selectedGrade == value) return;
                if (value == null)
                    throw new ArgumentNullException("value");
                if (!_grades.Contains(value))
                    throw new InvalidOperationException("Grade does not belong to this school");
                _selectedGrade = value;
            }
        }

        public double Gpa
        {
            get { return SelectedGrade.Gpa; }
        }

        public School(Grade[] grades)
        {
            if (grades == null)
                throw new ArgumentNullException("grades");
            if (grades.Length == 0)
                throw new ArgumentException("Must provide at least one grade object");
            _grades = grades;
            _selectedGrade = _grades[0];
        }

        public IEnumerator<Grade> GetEnumerator()
        {
            return ((IEnumerable<Grade>)_grades).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
