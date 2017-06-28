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
    public class Types_String : xTypes_String
    {
        public Types_String(ITestOutputHelper debug = null) : base(debug) { }
    }
}