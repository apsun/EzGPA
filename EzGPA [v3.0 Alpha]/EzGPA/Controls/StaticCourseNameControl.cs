using System;
using System.Windows.Forms;
using EzGPA.Core;

namespace EzGPA.Controls
{
    public class StaticCourseNameControl : CheckBox, INameControl
    {
        private readonly StaticCourse _course;

        public event EventHandler<EventArgs> EnabledStatusChanged;

        public bool CourseEnabled
        {
            get { return _course.Enabled; }
        }

        public StaticCourseNameControl(StaticCourse course)
        {
            _course = course;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            OnEnabledStatusChanged();
        }

        protected virtual void OnEnabledStatusChanged()
        {
            _course.Enabled = CourseEnabled;
            EventHandler<EventArgs> handler = EnabledStatusChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
