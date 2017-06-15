using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTStats
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.VS_Static)]
    public static class ClassNTStats_Methods
    {
        /// <summary>
        /// Calculate Parser stats for comments, blocks and empty lines.
        /// </summary>
        /// <param name="statistics">The statistics.</param>
        /// <param name="line">The line.</param>
        /// <returns>true if line is blank</returns>
        public static bool zParse_IsBlankLine(this ClassNTStats_ statistics, string line)
        {
            statistics.ClassTotalLines++;

            if (line.Trim() == "")
            {
                statistics.ClassTotalBlankLines++;
                return true;  //< =====================================================
            }

            if (line.Contains("/// ") == false)  // Documentation lines are counted in another method
            {
                if (line.Contains("//"))
                {
                    statistics.ClassTotalCommentLines++;  // add unit test for this line
                }
                else
                {
                    if (line.Contains(" enum ")) statistics.TotalEnumerals++;
                    //get { return _DTE_Command ?? (_DTE_Command = new DTE_Command()); }  // .zContains_All
                    if (line.zContains_All("get", "{", "??", "}") && line.Contains(".zContains_All") == false) statistics.TotalProperties++;  // add unit test for this line
                    //else if (line.zContains_Any("{", "}")) statistics.ClassTotalBlockLines++;
                    statistics.ClassTotalCodeLines++;
                }
                return false;
            }

            return false;
        }

        /// <summary>
        /// Updates the class stats from the method stats
        /// </summary>
        /// <param name="stats">The class stats</param>
        /// <param name="method">The method nt</param>
        public static void zUpdate(this ClassNTStats_ stats, MethodNT_ method)
        {
            var methodStats = method.Statistics;

            // Totals
            stats.TotalMethods++;
            if (method.Header.Header_Scope == enCode_Scope._public) stats.TotalMethods_Public++;

            // Lines - 
            stats.MethodTotalLines += methodStats.MethodTotalLines;
            stats.MethodTotalBodyLines += methodStats.MethodTotalBodyLines;
            if (stats.MethodMaxLines < methodStats.MethodTotalBodyLines) stats.MethodMaxLines = methodStats.MethodTotalBodyLines;
            stats.MethodAvgLines = stats.MethodTotalBodyLines/stats.TotalMethods;

            stats.ClassTotalCommentLines += methodStats.MethodTotalCommentLines;
            //stats.ClassTotalLines += methodStats.MethodTotalLines;           ----- Already calculated
            //stats.ClassTotalCodeLines += methodStats.MethodTotalBodyLines;   ----- Already calculated

            // Code
            stats.CodeMaintainability += methodStats.CodeMaintainability;
            stats.CodeComplexity += methodStats.CodeComplexity;
        }
    }
}
