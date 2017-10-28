using System;

namespace EzGPA.Controls
{
    public interface IScoreControl
    {
        /// <summary>
        /// Gets the score of the course, as a string. 
        /// May be null, if no input was entered.
        /// </summary>
        string CourseScore { get; }

        /// <summary>
        /// Raised when the score value of the course changes.
        /// </summary>
        event EventHandler<EventArgs> ScoreChanged;
    }
}
