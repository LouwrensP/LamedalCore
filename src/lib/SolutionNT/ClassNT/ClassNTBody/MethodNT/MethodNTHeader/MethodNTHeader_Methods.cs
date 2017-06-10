using System;
using System.Collections.Generic;
using System.Linq;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTHeader.MethodNTHeader_Parameter;
using LamedalCore.zz;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTHeader
{
    [BlueprintRule_Class(enBlueprintClassNetworkType.Undefined)]
    public sealed class MethodNTHeader_Methods
    {
        /// <summary>
        /// Parses the method header.
        /// </summary>
        /// <param name="sourceLines">The source lines.</param>
        /// <param name="ii">The ii.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="scope">The scope.</param>
        /// <param name="returnType">Type of the return.</param>
        /// <param name="kind">The kind.</param>
        /// <param name="specialty">The specialty.</param>
        /// <returns></returns>
        public static string Parse(List<string> sourceLines, ref int ii, out string methodName, out enCode_Scope scope,
            out string returnType, out enMethod_Kind kind, out enCode_Specialty specialty)
        {
            specialty = enCode_Specialty.IsNormal;
            kind = enMethod_Kind.IsFunction;
            string seek = "(";
            string methodLines = sourceLines[ii].Trim();

            //var jj = 0;
            if (methodLines.Contains("!!"))
            {
                //! Check if this is a property (as a quickfix ->properties will end with '!!')
                seek = "!!";
                kind = enMethod_Kind.IsProperty;
                if (methodLines.Contains("!!+")) kind = enMethod_Kind.IsSetter;
            }
            else
            {
                while (methodLines.Contains(")") == false) methodLines += " " + sourceLines[++ii].Trim(); //! Get the full method header
            }

            if (methodLines.Contains("<T>")) specialty = enCode_Specialty.IsGeneric;

            //! Parse the string and get the properties
            string methodBuffer = methodLines;
            string pre = seek.zVar_Next(ref methodBuffer); // "("
            string buffer = pre;

            string scopeStr = "_" + " ".zVar_Next(ref buffer);
            scope = scopeStr.zEnum_To_EnumValue<enCode_Scope>();

            returnType = " ".zVar_Next(ref buffer);
            if (returnType == "static")
            {
                specialty = (specialty == enCode_Specialty.IsNormal) ? enCode_Specialty.IsStatic : specialty | enCode_Specialty.IsStatic;
                returnType = " ".zVar_Next(ref buffer); // This is a static method -> do more work
            }

            if (returnType.Contains("<") && returnType.Contains(">") == false)
            {
                returnType += " " + ">".zVar_Next(ref buffer) + ">";
            }

            methodName = buffer;
            if (methodName == "")
            {
                //! Test for special case - this is constructor
                methodName = returnType;
                returnType = "";
            }

            //! Set last properties
            methodName = methodName.Trim();
            if (methodName.Contains("<")) methodName = methodName.zvar_Id("<");

            if (returnType == "void") kind = enMethod_Kind.IsVoid;
            if (returnType.zIsNullOrEmpty()) kind = enMethod_Kind.IsConstructor;

            return methodLines;
        }

        public static List<string> Str2StrList(string methodHeader)
        {
            // This method is used internally by the unit testing code
            List<string> result = methodHeader.zConvert_Array_FromStr("".NL()).ToList();
            return result;
        }

        /// <summary>
        /// Generate method signature method from method name, parameters and return type.
        /// </summary>
        /// <param name="methodName">The method name</param>
        /// <param name="parameters">The parameters list</param>
        /// <param name="returnType">The return type</param>
        /// <returns>string</returns>
        public static void ParameterSignature(string methodName, List<MethodNTHeader_Parameter_> parameters, string returnType, out string signature, out string parameterLine)
        {
            signature = "";
            parameterLine = "";
            var ref1 = "";
            foreach (MethodNTHeader_Parameter_ parameter in parameters)
            {
                if (signature.Length > 0)
                {
                    signature += ",";
                    parameterLine += ",";
                }
                switch (parameter.ParameterRefType)
                {
                    case enParameterRefType.ByReference: ref1 = " ref "; break;
                    case enParameterRefType.Output: ref1 = " out "; break;
                    case enParameterRefType.ParamArray: ref1 = " params "; break;
                    case enParameterRefType.ByValue: ref1 = ""; break;
                    default: throw new Exception($"Argument '{nameof(parameter.ParameterRefType)}' error.");

                }
                signature += ref1 + parameter.ParameterTypeName;
                parameterLine += ref1 + parameter.ParameterTypeName + " " + parameter.ParameterName;
            }
            signature = methodName + "(" + signature + ")";
            if (returnType != "void") signature += " : " + returnType;

        }
    }
}
