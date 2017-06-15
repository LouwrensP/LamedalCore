using System;
using System.Collections.Generic;
using System.Reflection;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttribute.ClassNTBlueprintRule;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.PropertyNT;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTHeader;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTStats;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.VS_Static)]
    public static class ClassNT_Methods
    {
        public const string codeSpace = "        ";

        /// <summary>
        /// Parses the specified sourceLines.
        /// </summary>
        /// <param name="sourceLines">The sourceLines.</param>
        /// <param name="ii">The ii.</param>
        /// <param name="classRef">The class reference.</param>
        /// <param name="error">if set to <c>true</c> [error].</param>
        /// <param name="classHeader">The class header.</param>
        /// <param name="methods">The tag_ methods.</param>
        /// <param name="properties">The tag_ properties.</param>
        /// <param name="statistics">The statistics.</param>
        /// <param name="blueprintRule">The blueprint rule.</param>
        public static void Parse_Class(List<string> sourceLines, ref int ii, ClassNT_ classRef, out bool error, out ClassNTHeader_ classHeader, out List<MethodNT_> methods, 
                    out List<PropertyNT_> properties, out ClassNTStats_ statistics, out ClassNTBlueprintRule_ blueprintRule)
        {
            // =======================================================================================
            // Note: The ii parameter is not used but is required by the ISourceCodeTemplate interface
            // =======================================================================================

            // Create property classes
            methods = new List<MethodNT_>();   // Methods contained in the class
            properties = new List<PropertyNT_>();
            blueprintRule = null;

            var Setup_RegionStack = new Stack<Tuple<string, int, bool>>();  // Region name, line no, 
            //Setup_SourceCode = sourceLines;

            // Variables needed to parse the body
            error = false;
            int iBlocks = 0;
            //bool header = true;
            bool methodStart = false;
            bool commentStart = false;
            statistics = ClassNTStats_.Create();

            statistics.ClassTotalLines = sourceLines.Count;

            //// Parse the header information
            //_Header = new sourceClassHeader_(sourceLines, ref ii, Tag_Statistics);
            classHeader = ClassNTHeader_.Create(sourceLines, out ii, statistics);
            if (classHeader != null) blueprintRule = ClassNTBlueprintRule_.Create(classHeader.NameSpace_AttributeLines);
            //ii++;

            //bool classHelp = false;
            string methodScope = "";

            int iiMethodStart = ii;
            int iiMethodEnd = 0;

            // Body ====================================
            for (; ii < sourceLines.Count; ii++)
            {
                string line = sourceLines[ii];

                if (iBlocks == 0)
                {
                    #region -[regions

                    if (line.Contains("#region"))
                    {
                        var region = line;
                        "#region ".zVar_Next(ref region);
                        if (region == "") region = "region";  // Needs unit test 
                        Setup_RegionStack.Push(Tuple.Create(region, ii, true)); // True indicate that a new region was found
                    }
                    if (line.Contains("#endregion"))
                    {
                        Setup_RegionStack.Pop();
                        if (Setup_RegionStack.Count > 0)   // Needs unit test 
                        {
                            Tuple<string, int, bool> region = Setup_RegionStack.Pop();
                            Setup_RegionStack.Push(Tuple.Create(region.Item1, region.Item2, false)); // Change value to false of top item on stack
                        }
                    }

                    #endregion

                    if (!commentStart)
                    {
                        if (line.Contains("/// ") && !line.Contains("////"))
                        {
                            commentStart = true;
                            iiMethodStart = ii;
                        }
                    }

                    if (methodStart == false)
                    {
                        #region -[Method Start

                        if (line.zContains_Any("(", ")") // Most methods will have this
                            && line.zContains_Any(out methodScope, StringComparison.CurrentCulture, "private", "public", "internal") // Most methods will have this
                            && line.zContains_All("=", "new") == false // Methods will not have this
                            && line.zContains_Any("/// ", " class ", " get ") == false  // Methods header line will not have these
                            && line.Trim().Substring(0, 1) != "[") //  This is a flag
                        {
                            if (line.zContains_All("(", "=") == false || line.IndexOf("=") >= line.IndexOf("("))
                            // If there is a '(' and '=' --> '(' must always be first 
                            {
                                methodStart = true;
                                if (commentStart == false) iiMethodStart = ii;
                                //iBlocks = 0;
                            }
                            // For a method the ';' will always follow the '(' and the  ')'
                            if (line.zContains_All("(", ";") && line.IndexOf(";") <= line.IndexOf("("))  // Needs unit test 
                            {
                                methodStart = false;
                            }
                        }
                        else if (commentStart && (line.Contains("/// ") == false && line.Contains("[Pure]") == false))
                        {
                            commentStart = false;
                        }

                        if (line.zContains_All("{", "}") == false) continue; //<================================

                        #endregion
                    }
                }

                // This is a simple property
                if (line.zContains_All("get", "{", "??", "}") && line.Contains(".zContains_All") == false)
                // Ignore this line in  myself      
                {
                    var test = line.Trim();
                    if (test.Length <= 2 || test.Substring(0, 2) != "//") // Make sure line is not commented out
                    {
                        var propertyLine = sourceLines[ii - 2].Trim();
                        var property = PropertyNT_.Create(propertyLine);
                        properties.Add(property);
                    }
                }

                // ================================================Method Body
                if (line.Contains("{"))
                {
                    iBlocks++;
                    commentStart = false;
                }

                #region -[Method End

                if (line.Contains("}") || (line.zContains_Any("private", "public", "internal") && line.Contains(");")))
                // or contains private / public with );  // private static extern bool SetForegroundWindow(IntPtr hWnd);
                {
                    if (line.Contains("}")) iBlocks--;
                    if (iBlocks == 0)
                    {
                        iiMethodEnd = ii;
                        #region debug
                        //var debug = false;
                        //if (debug) // || methodStart == false
                        //{
                        //    var source = LamedalCore_.Instance.Types.List.String.ToString(sourceLines, "".NL(), false, iiMethodStart,iiMethodEnd + 1);
                        //    ("Class Method found:" + source).zException_Show(action: enExceptionAction.ShowMessage);
                        //    break;
                        //}
                        #endregion

                        if (methodStart == true)
                        {
                            methodStart = false;
                            var method = MethodNT_.Create(sourceLines, ref iiMethodStart, iiMethodEnd, classRef);
                            methods.Add(method);
                            statistics.zUpdate(method);
                        }
                    }
                }

                #endregion
            }
        }

    }
}
