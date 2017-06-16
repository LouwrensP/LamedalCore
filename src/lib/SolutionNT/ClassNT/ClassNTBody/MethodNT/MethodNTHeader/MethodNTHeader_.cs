using System.Collections.Generic;
using System.Diagnostics;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTHeader.MethodNTHeaderParameter;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTHeader
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_State)]
    [DebuggerDisplay("Name = {Header_Name}; Signature = {Method_Signature}")]
    public sealed class MethodNTHeader_
    {
        public enCode_Scope Header_Scope = enCode_Scope._private;
        public enCode_MethodKind Header_Kind = enCode_MethodKind.IsVoid;
        public string Header_ReturnType;
        public string Header_Name;
        public enCode_Specialty Header_Specialty = enCode_Specialty.IsNormal;
        public readonly List<MethodNTHeaderParameter_> Header_Parameters = new List<MethodNTHeaderParameter_>();

        public string Method_HeaderLine;     // Original method header
        public string Method_Signature;     // The signature of the method
        public string Method_ParametersLine;

        public static MethodNTHeader_ Create(List<string> sourceLines, ref int ii)
        {
            var result = new MethodNTHeader_();
            // Execute static method to populate result parameters
            result.Method_HeaderLine = MethodNTHeader_Methods.Parse(sourceLines, ref ii, out result.Header_Name, out result.Header_Scope, out result.Header_ReturnType, out result.Header_Kind, out result.Header_Specialty);

            // Get the parameters
            List<string> parametersLines;
            MethodNTHeaderParameter_Methods.Parameters_Parse(result.Method_HeaderLine, out parametersLines);
            foreach (string paramLine in parametersLines)
            {
                var parameter = MethodNTHeaderParameter_.Create(paramLine);
                result.Header_Parameters.Add(parameter);
            }

            MethodNTHeader_Methods.ParameterSignature(result.Header_Name, result.Header_Parameters, result.Header_ReturnType,
                            out result.Method_Signature, out result.Method_ParametersLine);
            return result;
        }
    }
}
