using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LamedalCore.Types
{
    /// <summary>
    /// http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow
    /// http://stackoverflow.com/users/3312/jesse-c-slicer
    /// </summary>
    public sealed class Types_intRomanNumbers
    {
        private const int _NumberOfRomanNumeralMaps = 13;
        private const int _MinValue = 1;
        private const int _MaxValue = 3999;
        private readonly Dictionary<string, int> _romanNumerals = new Dictionary<string, int>(_NumberOfRomanNumeralMaps)
            {
                { "M", 1000 },
                { "CM", 900 },
                { "D", 500 },
                { "CD", 400 },
                { "C", 100 },
                { "XC", 90 },
                { "L", 50 },
                { "XL", 40 },
                { "X", 10 },
                { "IX", 9 },
                { "V", 5 },
                { "IV", 4 },
                { "I", 1 }
            };

        private readonly Regex _validRomanNumeral = new Regex(
            "^(?i:(?=[MDCLXVI])((M{0,3})((C[DM])|(D?C{0,3}))"
            + "?((X[LC])|(L?XX{0,2})|L)?((I[VX])|(V?(II{0,2}))|V)?))$",
            RegexOptions.Compiled);

        public bool IsValid(string value)
        {
            return _validRomanNumeral.IsMatch(value);
        }

        public int ToInt(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            value = value.ToUpperInvariant().Trim();
            int length = value.Length;

            if ((length == 0) || !IsValid(value)) throw new ArgumentException("Empty or invalid Roman numeral string.", nameof(value));

            var result = 0;
            var ii = length;

            while (ii > 0)
            {
                int digit = _romanNumerals[value[--ii].ToString()];

                if (ii > 0)
                {
                    int previousDigit = _romanNumerals[value[ii - 1].ToString()];
                    if (previousDigit < digit)
                    {
                        digit -= previousDigit;
                        ii--;
                    }
                }
                result += digit;
            }

            return result;
        }

        public string ToRoman(int value)
        {
            if ((value < _MinValue) || (value > _MaxValue)) throw new ArgumentOutOfRangeException(nameof(value), value, "Argument out of Roman numeral range.");

            const int MaxRomanNumeralLength = 15;
            var result = new StringBuilder(MaxRomanNumeralLength);

            foreach (var pair in _romanNumerals)
            {
                while (value / pair.Value > 0)
                {
                    result.Append(pair.Key);
                    value -= pair.Value;
                }
            }

            return result.ToString();
        }
    }
}
