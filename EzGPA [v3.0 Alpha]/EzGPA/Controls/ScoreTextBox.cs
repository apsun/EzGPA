using System;
using System.ComponentModel;
using System.Windows.Forms;
using EzGPA.Core;

namespace EzGPA.Controls
{
    public sealed class ScoreTextBox : TextBox, IScoreControl
    {
        private readonly Course _course;
        private readonly bool _initialized;

        public event EventHandler<EventArgs> ScoreChanged;

        [DefaultValue(false)]
        public bool ClearOnFocus { get; set; }

        [DefaultValue(false)]
        public bool SelectAllOnFocus { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CourseScore
        {
            get { return Text; }
        }

        public ScoreTextBox(Course course)
        {
            if (course.Score != null)
            {
                // Unlike the ComboBox control, we don't want to 
                // clear the score here, since the user is expected 
                // to enter invalid scores anyways.
                Text = course.Score;
            }

            _course = course;
            _initialized = true;
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

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            OnValueChanged(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (SelectAllOnFocus) SelectAll();
            else if (ClearOnFocus) Clear();
            base.OnGotFocus(e);
        }
    }
}
