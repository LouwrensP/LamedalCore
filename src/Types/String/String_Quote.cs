using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.Types.String
{
    /// <summary>
    /// Set quotes and new line characters
    /// </summary>
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action, DefaultType = typeof(string), GroupName = "Str")]
    public sealed class String_Quote
    {
        private readonly Types_Convert As = LamedalCore_.Instance.Types.Convert;
        private readonly Types_Object Object = LamedalCore_.Instance.Types.Object;

        /// <summary>Return new line characters for SQL strings.</summary>
        /// <returns>string</returns>
        [Pure]
        public string SQL_NL()
        {
            return "' + CHAR(13) + CHAR(10) + '";
        }

        /// <summary>
        /// Add comma and single quote to the specified inputStr.
        /// </summary>
        /// <param name="inputStr">The inputStr.</param>
        public string cQ(string inputStr)
        {
            return "," + Q(inputStr);
        }

        /// <summary>Add single quote string to the global unique identifier.</summary>
        /// <param name="guid">The global unique identifier</param>
        /// <returns>string</returns>
        [Pure]
        public string Q(Guid guid)
        {
            return "'" + guid + "'";
        }

        /// <summary>Add single quote string to the date inputStr.</summary>
        /// <param name="dateValue">The date inputStr</param>
        /// <returns>string</returns>
        [Pure]
        public string Q(DateTime dateValue)
        {
            return "'" + dateValue.Date.ToString("yyyy-MM-dd") + " 00:00:00'";
        }

        /// <summary>Add single quote string to the input string.</summary>
        /// <param name="inputStr">The input string</param>
        /// <returns>string</returns>
        [Pure]
        public string Q(string inputStr)
        {
            if (inputStr == null) return "NULL";
            return "'" + inputStr + "'";
        }

        /// <summary>Add double quote to the input string.</summary>
        /// <param name="inputStr">The input string</param>
        /// <returns>string</returns>
        [Pure]
        public string QQ(string inputStr)
        {
            if (inputStr == null) return "";

            return "\"" + inputStr.Replace("\"", "\\\"") + "\"";
        }

        /// <summary>Function to add single quote string to SQL object variables by inspecting the underlying type.</summary>
        /// <param name="Object">The object</param>
        /// <param name="addN">Add n indicator. Default inputStr = false.</param>
        /// <returns>string</returns>
        [Pure]
        public string SQL_Q(object Object, bool addN = false)
        {
            if (this.Object.IsNull(Object)) return "NULL";

            var result = As.Str_FromObj(Object);   // default inputStr

            if (Object is string)
            {
                var N = (addN) ? "N'" : "'";
                result = result.Replace("'", "''");
                result = N + result.Replace("".NL(), SQL_NL()) + "'";
                return result;
            }
            if (Object is DateTime || Object is Guid) return "'" + result + "'";
            if (Object is bool) return As.Bool_FromObj(Object) ? "1" : "0";
            if (this.Object.IsNumber(Object)) return result;

            // ===============
            // Error condition
            // ===============
            ("Error! Cannot convert type '" + Object.GetType() + "' to SQL!").zException_Show();  // Unable to test -> add unit test condition on error
            return null;
        }

        /// <summary>Word_FromAbbreviation all single quote characters to double single quotes to make it  SQL compatible.</summary>
        /// <param name="inputStr">The inputStr</param>
        /// <returns>string</returns>
        [Pure]
        public string SQL_Q(string inputStr)
        {
            if (inputStr == null) return "NULL";

            inputStr = inputStr.Replace("'", "''");   // Make it save if there is already a '
            return Q(inputStr);
        }

        /// <summary>
        /// Removes the double quotes from the line.
        /// </summary>
        /// <param name="line">The line</param>
        /// <returns>string</returns>
        [Pure]
        public string Remove_DoubleQuotes([NotNull] string line)
        {
            return line.Replace("\"", "");
        }

    }
}
