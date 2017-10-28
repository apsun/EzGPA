using System;
using System.Globalization;

namespace EzGPA.Config
{
    internal static class StringParser
    {
        public delegate bool TryParseFunc<T>(string value, out T result);
        public delegate T ParseFunc<out T>(string value);

        public static bool TryParseNullable<T>(string value, TryParseFunc<T> parser, out T? result)
            where T : struct
        {
            if (value == null)
            {
                result = null;
                return true;
            }
            T outValue;
            if (!parser(value, out outValue))
            {
                result = null;
                return false;
            }
            result = outValue;
            return true;
        }

        public static bool TryParse<T>(string value, ParseFunc<T> parser, out T result)
        {
            try
            {
                result = parser(value);
                return true;
            }
            catch
            {
                result = default (T);
                return false;
            }
        }

        public static bool TryParseDoubleStrict(string value, out double result)
        {
            bool success = double.TryParse(value, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out result);
            if (success && (double.IsNaN(result) || double.IsInfinity(result)))
            {
                result = 0;
                return false;
            }
            return success;
        }

        public static bool TryParseBoolNullable(string value, out bool? result)
        {
            return TryParseNullable(value, bool.TryParse, out result);
        }

        public static bool TryParseIntNullable(string value, out int? result)
        {
            return TryParseNullable(value, int.TryParse, out result);
        }

        public static bool TryParseDoubleNullable(string value, out double? result)
        {
            return TryParseNullable(value, double.TryParse, out result);
        }

        public static bool TryParseDoubleStrictNullable(string value, out double? result)
        {
            return TryParseNullable(value, TryParseDoubleStrict, out result);
        }

        public static bool TryParseGuid(string value, out Guid result)
        {
            return TryParse(value, s => new Guid(s), out result);
        }

        public static bool TryParseVersion(string value, out Version result)
        {
            return TryParse(value, s => new Version(s), out result);
        }
    }
}
