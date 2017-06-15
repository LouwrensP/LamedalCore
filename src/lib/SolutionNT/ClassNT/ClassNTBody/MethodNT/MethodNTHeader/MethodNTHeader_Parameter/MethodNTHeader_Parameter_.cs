using System.Diagnostics;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.lib.SolutionNT.ClassNT.ClassNTBody.MethodNT.MethodNTHeader.MethodNTHeader_Parameter
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_State)]
    [DebuggerDisplay("Name = {ParameterName}; Value = {ParameterValue}")]
    public sealed class MethodNTHeader_Parameter_
    {
        public bool ParmeterIsThis;
        public enCode_ParameterRefType ParameterRefType = enCode_ParameterRefType.ByValue;
        public string ParameterTypeName;
        public string ParameterName;
        public string ParameterValue;
        public string ParameterSourceLine;
        public string ParameterComment;         // This is assigned at a later stage.

        public static MethodNTHeader_Parameter_ Create(string parametersLine)
        {
            var result = new MethodNTHeader_Parameter_(); // {Name = name, Value = value};
            // Execute static method to populate result parameters
            result.ParameterSourceLine = parametersLine;
            MethodNTHeader_Parameter_Methods.Parameter_Parts(ref parametersLine, out result.ParmeterIsThis, out result.ParameterRefType, out result.ParameterTypeName, out result.ParameterName, out result.ParameterValue);
            return result;
        }

    }
}
