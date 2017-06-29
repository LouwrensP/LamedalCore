using LamdalCoreXunit_cSharp.ClassNT;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using Xunit.Abstractions;

namespace LamedalCore.Test.Tests
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class cSharp_Test : Xunit_cSharp
    {
        public cSharp_Test(ITestOutputHelper debug = null) : base(debug) { }
    }
}