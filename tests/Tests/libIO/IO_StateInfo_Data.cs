using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;

namespace LamedalCore.Test.Tests.libIO
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.Node_Data)]
    public sealed class IO_StateInfo_Data
    {
        [BlueprintData_Field(Caption = "What is your name [{0}]? ")]
        public string Name;

        [BlueprintData_Field(Caption = "What is your surname [{0}]? ")]
        public string Surname;
    }
}