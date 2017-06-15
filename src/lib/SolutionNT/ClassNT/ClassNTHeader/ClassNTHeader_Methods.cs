using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTComment;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTStats;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTHeader
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.VS_Static)]
    public static class ClassNTHeader_Methods
    {
        /// <summary>
        /// Setups the ClassHeader_ class.
        /// </summary>
        /// <param name="sourceLines">The source lines list</param>
        /// <param name="ii">The ii indexer reference variable</param>
        /// <param name="statistics">The class source statistics</param>
        /// <param name="Using">The using.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="nameSpace">The name space.</param>
        /// <param name="commentSummary">The comment summary.</param>
        /// <param name="commentLines">The comment lines.</param>
        public static bool Parse_ClassHeader(List<string> sourceLines, out int ii, ClassNTStats_ statistics, out List<string> Using, out List<string> attributes, out string nameSpace,
            out string commentSummary, out List<string> commentLines)
        {
            // Set initial parameters
            // ==========================
            var lamed = LamedalCore_.Instance;  // Create new instance of the blueprint library
            nameSpace = "";
            Using = new List<string>();
            attributes = new List<string>();
            string ctiCodeLine = "";
            commentSummary = null;
            commentLines = null;

            ii = 0;
            bool classHelp = false;
            // Header =========================
            for (; ii < sourceLines.Count; ii++)
            {
                string line = sourceLines[ii];
                if (statistics.zParse_IsBlankLine(line)) continue; // <--------------------------------------------------

                // using
                if (line.Contains("using "))
                {
                    string using1 = line.zvar_Value("using ").zSubStr_RemoveStrAtEnd(";");
                    Using.Add(using1);
                    //statistics.ClassTotalCodeLines++;
                    continue;
                }

                // namespace
                if (line.Contains("namespace "))
                {
                    nameSpace = lamed.Types.String.Search.Var_Value(line, "namespace ");
                    classHelp = true;
                }

                #region -[Help & Attributes
                // Lines here may contain help (between 'namespace' and 'class') 
                /*
                /// <summary>
                /// Class Table_Key. This class cannot be inherited. |Key|
                /// </summary>
                 */
                if (classHelp && line.Contains("/// ") || (line.Contains("[") && line.Contains("//") == false))
                {
                    int iiSave = ii;
                    string returnLine;
                    MethodNTComment_Methods.Documentation_Parts(sourceLines, ref ii, statistics, out commentLines, out commentSummary, out attributes, out returnLine, out ctiCodeLine);
                    line = sourceLines[ii];
                }

                #endregion

                // Class header line definition ===============================> 
                if (line.Contains(" class ") && line.zContains_Any("/// ", "// ") == false) return true;

                
            }
            return false;
        }

        public static void Parse_ClassDefinition(string line, string nameSpace, out string classKind, out string classScope, out string className,
            out string classBase, out string classnameGroup, out string classNameShortVersion)
        {
            classKind = null;
            classScope = null;
            className = null;
            classBase = null;
            classnameGroup = null;
            classNameShortVersion = null;
            if (line.Contains(" class ") == false || line.zContains_Any("/// ", "// ")) return;

            classKind = line.zvar_Id(" class ");
            classScope = " ".zVar_Next(ref classKind);
            classBase = line.zvar_Value(" class ");
            className = ":".zVar_Next(ref classBase).Trim();
            classBase = classBase.Trim();
            classnameGroup = LamedalCore_.Instance.Types.String.Word.Word_Last(nameSpace, ".");
            classNameShortVersion = className.Replace(classnameGroup, "");
            classNameShortVersion = classNameShortVersion.Replace("_", "");

            // CTIN
            //if (ctiCodeLine.zIsNullOrEmpty() == false) _CTIN = new sourceClassHeader_CTIN(Class_Name, ctiCodeLine);

            return;  // <=======================================================
        }

        /// <summary>
        /// Class name breakdown.
        /// </summary>
        /// <param name="className">The class name</param>
        /// <param name="ClassName1">Return the class name1</param>
        /// <param name="ClassName2">Return the class name2</param>
        public static void ClassNameBreakdown(string className, out string ClassName1, out string ClassName2)
        {
            ClassName1 = className.zvar_Id("_");
            ClassName2 = className.zvar_Value("_");
        }
    }
}
