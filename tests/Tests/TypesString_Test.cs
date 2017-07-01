using LamdalCoreXunit_Types.String;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using Xunit;
using Xunit.Abstractions;

namespace LamedalCore.Test.Tests
{
    [Trait("Category", "Types")]
    [Trait("Category", "Types List")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class TypesString_Test : xTypes_String
    {
        public TypesString_Test(ITestOutputHelper debug = null) : base(debug) { }
    }
}