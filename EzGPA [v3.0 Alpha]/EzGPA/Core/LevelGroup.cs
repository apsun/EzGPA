using System;
using System.Collections;
using System.Collections.Generic;

namespace EzGPA.Core
{
    /// <summary>
    /// Represents a collection of course levels.
    /// </summary>
    public class LevelGroup : IEnumerable<Level>
    {
        private readonly string _name;
        private readonly Level[] _levels;

        /// <summary>
        /// Gets the untranslated name of the level group.
        /// </summary>
        public string RawName
        {
            get { return _name; }
        }

        /// <summary>
        /// Gets the name of the level group.
        /// </summary>
        public string Name
        {
            get { return NameTranslator(_name); }
        }

        /// <summary>
        /// Gets the number of levels contained in the group.
        /// </summary>
        public int LevelCount
        {
            get { return _levels.Length; }
        }

        /// <summary>
        /// Gets whether the group is the default, unnamed level group.
        /// </summary>
        public bool IsDefaultGroup
        {
            get { return _name == null; }
        }

        /// <summary>
        /// Gets the level at the specified index.
        /// </summary>
        public Level this[int index]
        {
            get { return _levels[index]; }
        }

        /// <summary>
        /// Gets or sets the function responsible for 
        /// translating the name of the group.
        /// </summary>
        public StringTranslator NameTranslator { get; set; }

        /// <summary>
        /// Constructs a new level group.
        /// </summary>
        /// <param name="groupName">The name of the level group.</param>
        /// <param name="levels">An array of level objects to encapsulate.</param>
        public LevelGroup(string groupName, Level[] levels)
        {
            if (levels == null)
                throw new ArgumentNullException("levels");
            _name = groupName;
            _levels = levels;

            NameTranslator = x => x;
        }

        IEnumerator<Level> IEnumerable<Level>.GetEnumerator()
        {
            return ((IEnumerable<Level>)_levels).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _levels.GetEnumerator();
        }
    }
}
