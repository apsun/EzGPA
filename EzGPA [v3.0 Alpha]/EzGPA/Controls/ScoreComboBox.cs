using System;
using System.Windows.Forms;
using EzGPA.Core;

namespace EzGPA.Controls
{
    public sealed class ScoreComboBox : ComboBox, IScoreControl
    {
        private readonly Course _course;
        private readonly bool _initialized;

        public event EventHandler<EventArgs> ScoreChanged;

        public string CourseScore
        {
            get
            {
                return (string)SelectedItem;
            }
        }

        public ScoreComboBox(Course course)
        {
            // Add the table items to the combo box.
            // We don't need to keep the actual table entries; 
            // the string value should be enough, since it 
            // will be parsed later on anyways.
            foreach (TableEntry item in course.ScoreTable)
            {
                Items.Add(item.ToString());
            }

            if (course.Score != null)
            {
                TableEntry entry = course.ScoreTable.ParseScore(course.Score);
                if (entry == null)
                {
                    // In the case that the course's score is not a 
                    // valid selection for this control, clear the 
                    // stored score value. This also means there will 
                    // be no selected entry in the ComboBox.
                    course.Score = null;
                }
                else
                {
                    // The score value is valid, hurrah! We simply 
                    // select the item from the drop-down list.
                    SelectedItem = entry.ToString();
                }
            }

            _course = course;
            _initialized = true;
        }

        protected override void OnSelectedItemChanged(EventArgs e)
        {
            base.OnSelectedItemChanged(e);
            OnValueChanged(e);
        }

        private void OnValueChanged(EventArgs e)
        {
            if (_initialized)
            {
                _course.Score = CourseScore;
                EventHandler<EventArgs> handler = ScoreChanged;
                if (handler != null) handler(this, e);
            }
        }
    }
}
