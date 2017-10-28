using System;
using System.Linq;
using System.Windows.Forms;
using EzGPA.Core;

namespace EzGPA.Controls
{
    public sealed class GradeTabPage : TabPage
    {
        private const int DistanceBetweenPanels = 3;

        private readonly Grade _grade;

        public Grade Grade
        {
            get { return _grade; }
        }

        public event EventHandler<EventArgs> GpaUpdated;

        public GradeTabPage(Grade grade)
        {
            _grade = grade;
            int i = 0;
            foreach (CoursePanel panel in grade.Select(course => new CoursePanel(course)))
            {
                panel.Top += (i++ * (DistanceBetweenPanels + panel.Height));
                panel.GpaUpdated += OnGpaUpdated;
                Controls.Add(panel);
            }
        }

        private void OnGpaUpdated(object sender, EventArgs e)
        {
            EventHandler<EventArgs> handler = GpaUpdated;
            if (handler != null) handler(sender, e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (CoursePanel panel in Controls)
                {
                    panel.GpaUpdated -= OnGpaUpdated;
                    panel.Dispose();
                }
            }

            base.Dispose(disposing);
        }
    }
}