using System;
using System.Collections.Generic;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTAttributes
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.VS_Static)]
    public static class ClassNTAttributes_Methods
    {
        /// <summary>
        /// For an attribute this method will seperate its name and Parameters.
        /// </summary>
        /// <param name="attributeCode">The attribute code</param>
        /// <param name="attributeName">Return the attribute name</param>
        /// <param name="parameterStrList">Return the parameter string list</param>
        public static void Attribute_Parts(string attributeCode, out string attributeName, out List<string> parameterStrList)
        {
            attributeName = "";
            parameterStrList = new List<string>();

            if (attributeCode.zContains_All("[", "]") == false)
            {
                var ex = new ArgumentException($"Error! No attribute input parameter: '{attributeCode}'", nameof(attributeCode));
                LamedalCore_.Instance.Logger.LogMessage(ex);
                throw ex;
            }

            attributeCode = attributeCode.Replace("[", "").Replace("]", "");  //.Replace("(", " ").Replace(")", "");
            if (attributeCode.zContains_Any(" ", "(") == false)
            {
                attributeName = attributeCode;
                return;
            }

            attributeName = "(".zVar_Next(ref attributeCode);
            attributeCode = attributeCode.zSubStr_RemoveLastWord(")");

            while (attributeCode != "")
            {
                var parameter = ",".zVar_Next(ref attributeCode);
                parameterStrList.Add(parameter);
            }
        }

        /// <summary>
        /// Parse code lines and seperate each attribute from the other. Every line in the list will contain 1 and only 1 attribute.
        /// </summary>
        /// <param name="sourceCode">The source code list</param>
        /// <returns>List<string/></returns>
        public static List<string> Attributes_FromCode(List<string> sourceCode)
        {
            var attributeLines = new List<string>();
            var line = "";
            foreach (string code in sourceCode)
            {
                line += code.Trim();
                if (code.Contains("]") == false) continue;

                attributeLines.AddRange(Attributes_FromCodeLine(line));
                line = "";
            }
            return attributeLines;
        }

        public static List<string> Attributes_FromCodeLine(string line)
        {
            // Is there more than one attribute in the same line -> split the lines
            var attributes = new List<string>();
            List<string> attributeTest = line.zConvert_Str_ToListStr(",");
            string att = "";
            bool combine = false;
            int BraketOpen, BraketClose;
            foreach (string attTest in attributeTest)
            {
                var attTest2 = attTest.Trim();
                if (combine == false)
                {
                    if (attTest2.zContains_Any("(", ")") == false)
                    {
                        attributes.Add(attTest2);
                        continue;
                    }

                    if (attTest2.zContains_All("(", ")"))
                    {
                        BraketOpen = attTest2.zWord_Total("(");
                        BraketClose = attTest2.zWord_Total(")");
                        if (BraketOpen == BraketClose)
                        {
                            // [BlueprintCodeInjection_(typeof(Controller_BlueprintLogger)   ==> should not be a positive
                            attributes.Add(attTest2);
                            continue;                            
                        }
                    }
                }
                // Combine all attribute parameters
                combine = true;
                if (att != "") att += ", ";
                att += attTest2;

                if (att.zContains(")"))
                {
                    BraketOpen = att.zWord_Total("(");
                    BraketClose = att.zWord_Total(")");
                    if (BraketOpen == BraketClose)
                    {

                        attributes.Add(att);
                        att = "";
                        combine = false;
                    }
                }
            }

            if (attributes.Count > 1)
            {
                for (int ii = 0; ii < attributes.Count; ii++)
                {
                    if (ii > 0) attributes[ii] = "[" + attributes[ii];
                    if (attributes[ii].zContains("(") && attributes[ii].zContains(")") == false) attributes[ii] += ")";  // unable to test this condition - add test case
                    if (attributes[ii].zContains("]") == false) attributes[ii] += "]";
                }
            }
            return attributes;
        }
    }
}
