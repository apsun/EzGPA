using System;
using System.Windows.Forms;
using EzGPA.Core;

namespace EzGPA.Controls
{
    public sealed class MultiGradeTabControl : TabControl
    {
        private readonly School _school;

        public School School
        {
            get { return _school; }
        }

        public event EventHandler<EventArgs> GpaUpdated;

        public MultiGradeTabControl(School school)
        {
            _school = school;
            foreach (Grade grade in school)
            {
                GradeTabPage page = new GradeTabPage(grade);
                page.GpaUpdated += OnGpaUpdated;
                TabPages.Add(page);
                if (school.SelectedGrade == grade)
                    SelectedTab = page;
            }
        }

        private void OnGpaUpdated(object sender, EventArgs e)
        {
            EventHandler<EventArgs> handler = GpaUpdated;
            if (handler != null) handler(sender, e);
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            _school.SelectedGrade = ((GradeTabPage)SelectedTab).Grade;
            OnGpaUpdated(this, EventArgs.Empty);
            base.OnSelectedIndexChanged(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (GradeTabPage page in TabPages)
                {
                    page.GpaUpdated -= OnGpaUpdated;
                    page.Dispose();
                }
            }

            base.Dispose(disposing);
        }
    }
}
