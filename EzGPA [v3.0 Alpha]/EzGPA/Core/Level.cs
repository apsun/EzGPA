using System;

namespace EzGPA.Core
{
    /// <summary>
    /// Represents a single course level and its corresponding bonus GPA.
    /// </summary>
    public class Level
    {
        private readonly string _name;
        private readonly double _bonusGpa;

        /// <summary>
        /// Gets the untranslated name of the level.
        /// </summary>
        public string RawName
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the localized name of the level.
        /// </summary>
        public string Name
        {
            get { return NameTranslator(_name); }
        }

        /// <summary>
        /// Gets the bonus GPA associated with the level.
        /// </summary>
        public double BonusGpa
        {
            get { return _bonusGpa; }
        }

        /// <summary>
        /// Gets or sets the function responsible for localizing 
        /// the name of the level.
        /// </summary>
        public StringTranslator NameTranslator { get; set; }

        /// <summary>
        /// Constructs a new level container.
        /// </summary>
        /// <param name="name">The name of the level.</param>
        /// <param name="bonusGpa">The bonus GPA associated with the level.</param>
        public Level(string name, double bonusGpa)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (bonusGpa < 0)
                throw new ArgumentOutOfRangeException("bonusGpa");
            _name = name;
            _bonusGpa = bonusGpa;

            NameTranslator = x => x;
        }
    }
}
