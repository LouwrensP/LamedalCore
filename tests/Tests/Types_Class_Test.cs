using LamdalCoreXunit_Types.Class;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using Xunit;
using Xunit.Abstractions;

namespace LamedalCore.Test.Tests
{
    [Trait("Category", "Types")]
    [Trait("Category", "Types Class")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class Types_Class_Test : xTypes_Class
    {
        public Types_Class_Test(ITestOutputHelper debug = null) : base(debug) { }
    }
}
