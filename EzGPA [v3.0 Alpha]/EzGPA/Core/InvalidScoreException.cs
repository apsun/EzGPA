using System;

namespace EzGPA.Core
{
    /// <summary>
    /// Raised when a score cannot be converted into a GPA value.
    /// </summary>
    public class InvalidScoreException : Exception
    {
        /// <summary>
        /// Creates a new instance of this exception.
        /// </summary>
        /// <param name="scoreValue">The score value that caused the exception.</param>
        public InvalidScoreException(string scoreValue)
            : this(scoreValue, null)
        {
            
        }

        /// <summary>
        /// Creates a new instance of this exception.
        /// </summary>
        /// <param name="scoreValue">The score value that caused the exception.</param>
        /// <param name="innerException">The exception that caused the exception.</param>
        public InvalidScoreException(string scoreValue, Exception innerException)
            : base("Invalid score value: " + scoreValue, innerException)
        {

        }
    }
}
