using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTHeader;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTstats
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.VS_Static)]
    public static class MethodNTstats_Methods
    {

        /// <summary>Simplify the methods code in order to do analysis on it.</summary>
        /// <param name="sourceLines">The source lines.</param>
        /// <returns></returns>
        public static string Code_Simplify(List<string> sourceLines)
        {
            string methodBody = sourceLines.zTo_Str("".NL());
            // Rip out single line comments.
            methodBody = Regex.Replace(methodBody, @"//.*" + Environment.NewLine, Environment.NewLine);

            // Rip out multi-line comments.
            methodBody = Regex.Replace(methodBody, @"/\*.*\*/", String.Empty, RegexOptions.Singleline);

            // Rip out strings.
            methodBody = Regex.Replace(methodBody, @"""[^""]*""", String.Empty);

            // Rip out characters.
            methodBody = Regex.Replace(methodBody, @"'[^']*'", String.Empty);

            // Remove double spaces and enters
            //methodBody = Regex.Replace(methodBody, @"( |\r?\n)\1+", "$1");
            methodBody = methodBody.Replace("  ", " ");
            methodBody = methodBody.Replace("".NL()+" ".NL(), "".NL());

            // Remove double tabs
            methodBody = Regex.Replace(methodBody, @"( |\t|\r?\n)\1+", "$1");
            return methodBody;
        }

        /// <summary>Total number of branching in code.</summary>
        /// <param name="methodBody">The method body.</param>
        /// <returns></returns>
        public static int Code_TotalBranching(string methodBody)
        {
            int ifCount = Regex.Matches(methodBody, @"\sif[\s\(]").Count;
            int elseCount = Regex.Matches(methodBody, @"\selse\s").Count;
            int elseIfCount = Regex.Matches(methodBody, @"\selse if[\s\(]").Count;
            int switchCount = Regex.Matches(methodBody, @"\sswitch[\s\(]").Count;
            int caseCount = Regex.Matches(methodBody, @"\scase\s[^;]*;").Count;
            int andCount = Regex.Matches(methodBody, @"\&\&").Count;
            int orCount = Regex.Matches(methodBody, @"\|\|").Count;
            int catchCount = Regex.Matches(methodBody, @"\scatch[\s\(]").Count;

            var result = ifCount + elseCount - elseIfCount + // else if will have been counted twice already by 'if' and 'else'
                switchCount + caseCount + andCount + orCount + catchCount;
            return result;
        }

        /// <summary>Total number of branching in code.</summary>
        /// <param name="methodBody">The method body.</param>
        /// <returns></returns>
        public static int Code_TotalLooping(string methodBody)
        {
            int whileCount = Regex.Matches(methodBody, @"\swhile[\s\(]").Count;
            int forCount = Regex.Matches(methodBody, @"\sfor[\s\(]").Count;
            int forEachCount = Regex.Matches(methodBody, @"\sforeach[\s\(]").Count;

            var result = whileCount + forCount + forEachCount;
            return result;
        }

        /// <summary>
        /// Calculates the complexity of the given method body. The higher the count the more complex the method.
        /// </summary>
        /// <param name="methodBody">The function text.</param>
        /// <returns>
        /// The calculated complexity.
        /// </returns>
        public static int Method_Complexity(string methodBody, MethodNTHeader_ header = null)
        {
            // Branching
            int branching = Code_TotalBranching(methodBody);

            // Looping
            int looping = Code_TotalLooping(methodBody);

            // Complexity
            int tertiaryCount = Regex.Matches(methodBody, @"\s\?\s").Count;

            // Parameters
            int parameters = (header == null) ? 0 : header.Header_Parameters.Count;

            int complexity = 1 + branching + looping +tertiaryCount + parameters;

            return complexity;
        }

        /// <summary>Maintainability calculation of method from the method body.</summary>
        /// <param name="methodBody">The method body</param>
        /// <param name="refMethodCount">The number of reference methods found in the code.</param>
        /// <param name="header">The header.</param>
        /// <returns>int</returns>
        public static int Method_Maintainability(string methodBody, int refMethodCount, MethodNTHeader_ header = null)
        {
            // Ideas:  Lines of code; parameters; complexity rating; 
            int complexity = Method_Complexity(methodBody);

            // Parameters
            double parameters = (header == null) ? 0 : header.Header_Parameters.Count;

            // Lines
            double lineBreaks = Regex.Matches(methodBody, @"\r\n").Count - (refMethodCount*2);

            // Factor (from parameters and lines)
            double factor = lineBreaks/10 + parameters/3;

            int result = (int)(complexity*factor);
            return result;
        }


        /// <summary>
        /// Parse method body.
        /// </summary>
        /// <param name="sourceLines">The source lines.</param>
        /// <param name="complexity">Return the complexity</param>
        /// <param name="maintainability">Return the maintainability</param>
        /// <param name="ReferenceCalls">The reference calls.</param>
        /// <param name="header"></param>
        public static void Method_Stats(List<string> sourceLines, out int complexity, out int maintainability, 
                    out List<string> ReferenceCalls, MethodNTHeader_ header = null)
        {
            ReferenceCalls = Method_ReferenceCalls(sourceLines);   // Calculate the reference calls

            string methodBody = Code_Simplify(sourceLines);
            complexity = Method_Complexity(methodBody);
            maintainability = Method_Maintainability(methodBody, ReferenceCalls.Count);
        }

        /// <summary>Calculates Method reference calls.</summary>
        /// <param name="sourceLines">The source lines.</param>
        /// <returns></returns>
        public static List<string> Method_ReferenceCalls(List<string> sourceLines)
        {
            var result = new List<string>();
            foreach (string line in sourceLines)
            {
                string methodCall;
                if (CodeLine_ReferenceCall(line, out methodCall)) result.Add(methodCall);
            }
            return result;
        }

        /// <summary>
        /// Determines whether the code line has a method call reference. 
        /// </summary>
        /// <param name="codeLine">The code line</param>
        /// <param name="methodCall">Return the method call</param>
        /// <returns>bool</returns>
        public static bool CodeLine_ReferenceCall(string codeLine, out string methodCall)
        {
            // Identify method that are called
            methodCall = "";
            var end = "";
            if (codeLine.zContains_All("(", ");")) end = ");";
            else if (codeLine.zContains_All("(", ") ")) end = ") ";

            if (end.Length > 0)
            {
                // This is a method -> work way back to first space from right
                string buffer = codeLine.zvar_Id(end); // Remove all after the method call
                buffer = buffer.Replace("if (", "");   // Remove any if statements
                buffer = buffer.zvar_Id("("); // Remove parameters
                buffer = buffer.zSubstr_LastWord(" "); // Call is all after the last space
                methodCall = buffer.zvar_Value(".");   // Method must have at least one .
                if (methodCall == "") return false;
                if (methodCall.Contains(".") || methodCall[0] == 'z') return true;
            }
            return false;
        }

        /// <summary>
        /// Parse the code line for method reference call .
        /// </summary>
        /// <param name="codeLine">The code line</param>
        /// <returns>string</returns>
        public static string CodeLine_ReferenceCall(string codeLine)
        {
            string methodCall;
            if (CodeLine_ReferenceCall(codeLine, out methodCall)) return methodCall;
            return "";
        }
    }
}
