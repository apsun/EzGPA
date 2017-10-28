using System.Windows.Forms;
using EzGPA.Core;

namespace EzGPA.Controls
{
    public class DynamicCourseNameControl : Panel, INameControl
    {
        private readonly DynamicCourse _course;
        private readonly CheckBox _enabledCheckBox;
        private readonly ComboBox _courseComboBox;

        public bool CourseEnabled { get; set; }

        public DynamicCourseNameControl(DynamicCourse course)
        {
            _course = course;
            _enabledCheckBox = new CheckBox();
            _courseComboBox = new ComboBox();
            Controls.Add(_enabledCheckBox);
            Controls.Add(_courseComboBox);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _enabledCheckBox.Dispose();
                _courseComboBox.Dispose();
            }
            
            base.Dispose(disposing);
        }
    }
}
