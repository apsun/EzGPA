using System;

namespace EzGPA.Controls
{
    public interface INameControl
    {
        /// <summary>
        /// Gets whether the course should be included in GPA calculations.
        /// </summary>
        bool CourseEnabled { get; }

        /// <summary>
        /// Raised when the enabled status of the course changes.
        /// </summary>
        event EventHandler<EventArgs> EnabledStatusChanged;
    }
}
