using System;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.Types.String
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Action, DefaultType = typeof(string), GroupName = "Str")]
    public sealed class String_Regex
    {
        /// <summary>
        /// Test if 'inputStr' is Alpha.
        /// </summary>
        /// <param name="inputStr">The @inputStr to act on.</param>
        /// <returns>true if Alpha, false if not.</returns>
        public bool IsAlpha(string inputStr)
        {
            var regex = new Regex(@"[^a-zA-Z]");
            var match = regex.Match(inputStr);
            return !match.Success;
        }

        /// <summary>
        /// Indicates whether the current string matches the supplied wildcard pattern.  Behaves the same
        /// as VB's "Like" Operator.
        /// http://stackoverflow.com/questions/271398/what-are-your-favorite-extension-methods-for-c-codeplex-com-extensionoverflow?page=2&tab=votes#tab-top
        /// </summary>
        /// <param name="text">The string instance where the extension method is called</param>
        /// <param name="wildcardPattern">The wildcard pattern to match.  Syntax matches VB's Like operator.</param>
        /// <returns>true if the string matches the supplied pattern, false otherwise.</returns>
        /// <remarks>See http://msdn.microsoft.com/en-us/library/swf8kaxw(v=VS.100).aspx</remarks>
        public bool IsLike(string text, string wildcardPattern)
        {
            if (text.zIsNullOrEmpty()) return false;
            if (wildcardPattern.zIsNullOrEmpty()) return false;

            // turn into regex pattern, and match the whole string with ^$
            var regexPattern = "^" + Regex.Escape(wildcardPattern) + "$";

            // add support for ?, #, *, [], and [!]
            regexPattern = regexPattern.Replace(@"\[!", "[^")
                                       .Replace(@"\[", "[")
                                       .Replace(@"\]", "]")
                                       .Replace(@"\?", ".")
                                       .Replace(@"\*", ".*")
                                       .Replace(@"\#", @"\d");

            var result = false;
            try
            {
                result = Regex.IsMatch(text, regexPattern);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(string.Format("Invalid pattern: {0}", wildcardPattern), ex);
            }
            return result;
        }

        /// <summary>Verifies simple email expressions. Doesn't allow numbers in the domain name and doesn't allow for top level domains that are less than 2 or more than 3 letters (which is fine until they allow more). Doesn't handle multiple &quot;.&quot; in the domain.</summary>
        /// <param name="inputToTest">The input that needs to be tested.</param>
        /// <returns></returns>
        public bool IsMaliciousCode(string inputToTest)
        {
            // Source: http://regexlib.com/RETester.aspx?regexp_id=977
            var regex =
                new Regex(
                    @"(script)|(<)|(>)|(%3c)|(%3e)|(SELECT)|(UPDATE)|(INSERT)|(DELETE)|(GRANT)|(REVOKE)| (&lt;) |(&gt;)",
                    RegexOptions.IgnoreCase);
            var match = regex.Match(inputToTest);
            return match.Success;
        }

        /// <summary>Verifies simple email expressions. Doesn't allow numbers in the domain name and doesn't allow for top level domains that are less than 2 or more than 3 letters (which is fine until they allow more). Doesn't handle multiple &quot;.&quot; in the domain.</summary>
        /// <param name="eMailAddress">The email address.</param>
        /// <returns></returns>
        public bool IsValid_eMail(string eMailAddress)
        {
            // Source: http://regexlib.com/DisplayPatterns.aspx?cattabindex=0&categoryId=1
            var regex = new Regex(@"(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})");
            var match = regex.Match(eMailAddress);
            return match.Success;
        }

        /// <summary>Verifies the format of IP Addresses.</summary>
        /// <param name="ipAddress">The IP address.</param>
        /// <returns></returns>
        public bool IsValid_IP(string ipAddress)
        {
            // Source: http://regexlib.com/DisplayPatterns.aspx?cattabindex=1&categoryId=2
            var regex =
                new Regex(
                    @"^(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])$");
            var match = regex.Match(ipAddress);
            return match.Success;
        }
        /// <summary>Test for valid Url. whether they had HTTP in front or not. This will find those that don't have hyphens anywhere in them (except for after the domain)</summary>
        /// <param name="URL">The in URL.</param>
        /// <returns></returns>
        public bool IsValid_Url(string URL)
        {
            // Source: http://regexlib.com/DisplayPatterns.aspx?cattabindex=1&categoryId=2
            var regex =
                new Regex(
                    @"^(?<link>((?<prot>http:\/\/)*(?<subdomain>(www|[^\-\n]*)*)(\.)*(?<domain>[^\-\n]+)\.(?<after>[a-zA-Z]{2,3}[^>\n]*)))$");
            var match = regex.Match(URL);
            return match.Success;
        }

        /// <summary>Verifies URLs. Checks for the leading protocol, a good looking domain (two or three letter TLD; no invalid characters in domain) and a somwhat reasonable file path.</summary>
        /// <param name="httpURL">The HTTP address.</param>
        /// <returns></returns>
        public bool IsValid_UrlHttp(string httpURL)
        {
            if (IsValid_Url(httpURL) == false) return false;

            // Source: http://regexlib.com/DisplayPatterns.aspx?cattabindex=1&categoryId=2
            var regex = new Regex(@"^http\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(/\S*)?$");
            var match = regex.Match(httpURL);
            return match.Success;
        }

        /// <summary>Determines whether [is valid_ regex] [the specified _regex pattern].</summary>
        /// <param name="_regexPattern">The _regex pattern.</param>
        /// <param name="errorMsg">The error MSG.</param>
        /// <param name="_regexOptions">The _regex options.</param>
        /// <returns></returns>
        public bool IsValid_Regex(string _regexPattern, out string errorMsg, RegexOptions _regexOptions = RegexOptions.None)
        {
            try
            {
                var _regex = new Regex(_regexPattern, _regexOptions);
            }
            catch (Exception ex)
            {
                errorMsg = "Regex Error! " +ex.Message;
                return false;
            }
            errorMsg = "";
            return true;
        }

        /// <summary>Replaces the input string between the start marker and end marker with the replace string.</summary>
        /// <param name="marker_start">The start marker</param>
        /// <param name="marker_end">The end marker</param>
        /// <param name="inputStr">The input string</param>
        /// <param name="replaceStr">The replace string</param>
        /// <returns>string</returns>
        [Pure]
        public string Replace_Between(string marker_start, string marker_end, string inputStr, string replaceStr)
        {
            marker_start = Replace_Between_Makers(marker_start);
            marker_end = Replace_Between_Makers(marker_end);
            var searchPattern = "(<marker_start>)(.*?)(<marker_end>)".Replace("<marker_start>", marker_start).Replace("<marker_end>", marker_end);

            var regex = new Regex(searchPattern);
            var result = regex.Replace(inputStr, "$1" + replaceStr + "$3");
            return result;
        }

        /// <summary>Converts the start marker into save string.</summary>
        /// <param name="marker_start">The start marker</param>
        /// <returns>string</returns>
        [Pure]
        private string Replace_Between_Makers(string marker_start)
        {
            var result = marker_start.Replace("[", "\\[").Replace("]", "\\]");
            return result;
        }
    }
}
