using System;
using EzGPA.Core;

namespace EzGPA.Controls
{
    public interface ILevelControl
    {
        /// <summary>
        /// Gets the selected level of the course.
        /// </summary>
        Level SelectedLevel { get; }

        /// <summary>
        /// Raised when the selected level of the course changes.
        /// </summary>
        event EventHandler<EventArgs> SelectedLevelChanged;
    }
}
