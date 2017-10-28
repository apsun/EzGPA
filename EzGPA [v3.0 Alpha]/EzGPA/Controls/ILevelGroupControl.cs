using System;
using EzGPA.Core;

namespace EzGPA.Controls
{
    public interface ILevelGroupControl
    {
        /// <summary>
        /// Gets the selected level group of the course.
        /// </summary>
        LevelGroup SelectedGroup { get; }

        /// <summary>
        /// Raised when the selected level group of the course changes.
        /// </summary>
        event EventHandler<EventArgs> SelectedGroupChanged;
    }
}
