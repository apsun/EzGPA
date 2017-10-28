using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace EzGPA.Core
{
    /// <summary>
    /// Specifies various methods for score input. A compliant UI implementation 
    /// will map each of these entry methods to a control type.
    /// </summary>
    public enum ScoreInputType
    {
        /// <summary>
        /// Generally means the user will input their score into a textbox, 
        /// which will then be validated.
        /// </summary>
        Free,
        /// <summary>
        /// Generally means the user will select their score from a drop-down 
        /// list, so that all input values are valid.
        /// </summary>
        Select
    }

    /// <summary>
    /// Handles converting a score into its corresponding GPA value.
    /// </summary>
    public class ScoreTable : IEnumerable<TableEntry>
    {
        private readonly TableEntry[] _entries;
        private readonly ScoreInputType _entryMethod;

        /// <summary>
        /// Gets the number of accepted values or ranges in the score table.
        /// </summary>
        public int EntryCount
        {
            get { return _entries.Length; }
        }

        /// <summary>
        /// Gets the preferred control for entering scores using the score table, 
        /// as defined in the configuration file.
        /// </summary>
        public ScoreInputType EntryMethod
        {
            get { return _entryMethod; }
        }

        /// <summary>
        /// Constructs a new score table object.
        /// </summary>
        /// <param name="entries">The entries used in the table.</param>
        /// <param name="entryMethod">The configuration-defined preferred score entry method.</param>
        public ScoreTable(TableEntry[] entries, ScoreInputType entryMethod)
        {
            if (entries == null)
                throw new ArgumentNullException("entries");
            if (entries.Length == 0)
                throw new ArgumentException("Must provide at least one table entry");
            _entries = entries;
            _entryMethod = entryMethod;
        }

        /// <summary>
        /// Converts the specified score into a GPA value. If the 
        /// score does not match any table entries, this will throw 
        /// an exception.
        /// </summary>
        /// <param name="score">The score to convert.</param>
        /// <param name="bonusGpa">The bonus GPA, which is conditionally added to the total GPA.</param>
        public double GetGpa(string score, double bonusGpa)
        {
            TableEntry entry = ParseScore(score);
            if (entry == null)
                throw new InvalidScoreException(score);
            return entry.GetGpa(bonusGpa);
        }

        /// <summary>
        /// Gets the table entry associated with the specified score 
        /// or score range representation. This is used when loading 
        /// configuration values and when finding the GPA value. If the 
        /// score does not match any table entries, this returns null.
        /// </summary>
        /// <param name="score">The score used to look up the appropriate table entry.</param>
        public TableEntry ParseScore(string score)
        {
            return _entries.FirstOrDefault(entry => entry.IsValid(score));
        }

        public IEnumerator<TableEntry> GetEnumerator()
        {
            return ((IEnumerable<TableEntry>)_entries).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// An entry in a score table, representing one GPA value for some input score.
    /// </summary>
    public abstract class TableEntry
    {
        private readonly double _baseGpa;
        private readonly bool _bonus;

        /// <summary>
        /// Gets the GPA value associated with the table entry.
        /// </summary>
        public double BaseGpa
        {
            get { return _baseGpa; }
        }

        /// <summary>
        /// Whether the bonus GPA should be added to the base GPA value.
        /// </summary>
        public bool Bonus
        {
            get { return _bonus; }
        }

        /// <summary>
        /// Constructs a new table entry object.
        /// </summary>
        /// <param name="baseGpa">The base GPA associated with the table entry.</param>
        /// <param name="bonus">Whether a bonus GPA should be added when calculating the GPA value.</param>
        protected TableEntry(double baseGpa, bool bonus)
        {
            _baseGpa = baseGpa;
            _bonus = bonus;
        }

        /// <summary>
        /// Gets the GPA value associated with this table entry and the provided bonus GPA value. 
        /// This table entry's value can only be used in GPA calculation if IsValid() returns true.
        /// </summary>
        /// <param name="bonusGpa">The bonus GPA, which is optionally added to the GPA value.</param>
        public double GetGpa(double bonusGpa)
        {
            if (Bonus) return BaseGpa + bonusGpa;
            return BaseGpa;
        }

        /// <summary>
        /// Returns whether the score is valid for this table entry.
        /// </summary>
        /// <param name="score">The score to check.</param>
        public abstract bool IsValid(string score);

        /// <summary>
        /// Returns a string representation of the score(s) valid for this table entry.
        /// </summary>
        public abstract override string ToString();
    }

    public class StringTableItem : TableEntry
    {
        private readonly string _value;

        public string Value
        {
            get { return _value; }
        }

        public StringTableItem(string value, double baseGpa, bool bonus) : base(baseGpa, bonus)
        {
            if (value == null)
                throw new ArgumentNullException("value");
            _value = value;
        }

        public override bool IsValid(string score)
        {
            return score == Value;
        }

        public override string ToString()
        {
            return Value;
        }
    }

    public class IntTableItem : TableEntry
    {
        private readonly int _value;

        public int Value
        {
            get { return _value; }
        }

        public IntTableItem(int value, double baseGpa, bool bonus) : base(baseGpa, bonus)
        {
            _value = value;
        }

        public override bool IsValid(string score)
        {
            int intScore;
            if (!int.TryParse(score, out intScore))
                return false;
            return intScore == Value;
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }
    }

    public class IntTableRange : TableEntry
    {
        private readonly int? _lower;
        private readonly int? _upper;

        public int? Lower
        {
            get { return _lower; }
        }

        public int? Upper
        {
            get { return _upper; }
        }

        public IntTableRange(int? lower, int? upper, double baseGpa, bool bonus)
            : base(baseGpa, bonus)
        {
            if (lower == null && upper == null)
                throw new ArgumentException("At least one bound must be specified");
            _lower = lower;
            _upper = upper;
        }

        public override bool IsValid(string score)
        {
            if (score == ToString())
                return true;
            int intScore;
            if (!int.TryParse(score, out intScore))
                return false;
            if (Lower != null && intScore < Lower.Value)
                return false;
            if (Upper != null && intScore > Upper.Value)
                return false;
            return true;
        }

        public override string ToString()
        {
            if (Lower == null)
                return Upper + "+";
            if (Upper == null)
                return Lower + "-";
            return Lower + "~" + Upper;
        }
    }
}