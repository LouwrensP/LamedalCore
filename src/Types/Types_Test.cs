using System;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.Types.String;

namespace LamedalCore.Types
{
    /// <summary>
    /// Conduct a test on the string excluding searching for patterns or values
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action, DefaultType = typeof(string), GroupName = "Str")]
    public sealed class Types_Test
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        /// <summary>Determines whether [is valid string] [the specified s].</summary>
        /// <param name="s">The string</param>
        /// <returns></returns>
        [BlueprintRule_MethodAliasDef(MirrorClass = typeof(String_Search))]
        public bool IsValidStr(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;

            s = s.Trim();
            if (s == "\0") return false;
            if (s.Length > 0)
            {
                char c = Convert.ToChar(s[0]);
                if (char.IsControl(c)) return false; // if (s == "\u0001") return false;
            }

            #region todo
            /*
             * Escape Sequence        Character Name               Unicode Encoding
                \'                     Single quote                 0x0027
                \"                     Double quote                 0x0022
                \\                     Backslash                    0x005C
                \0                     Null                         0x0000
                \a                     Alert                        0x0007
                \b                     Backspace                    0x0008
                \f                     Form feed                    0x000C
                \n                     newline                      0x000A
                \r                     Carriage return              0x000D
                \t                     Horizontal tab               0x0009
                \v                     Vertical tab                 0x000B
                \uxxxx                 Unicode character in hex     \u0029
                */
            #endregion

            return true;
        }

        /// <summary>A string extension method that query if '@inputStr' is numeric.</summary>
        /// <param name="inputStr">The @inputStr to act on.</param>
        /// <returns>true if numeric, false if not.</returns>
        public bool IsNumeric(string inputStr)
        {
            double retNum;
            bool result = Double.TryParse(inputStr, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return result;
        }

        /// <summary>Test if 'inputStr' is Alpha.</summary>
        /// <param name="inputStr">The @inputStr to act on.</param>
        /// <returns>true if Alpha, false if not.</returns>
        public bool IsAlpha(string inputStr)
        {
            return _lamed.Types.String.Regex.IsAlpha(inputStr);
        }
    }
}
