using LamdalCoreXunit_Types.List;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using Xunit;
using Xunit.Abstractions;

namespace LamedalCore.Test.Tests
{
    [Trait("Category", "Types")]
    [Trait("Category", "Types List")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class TypesList_Test : xTypes_List
    {
        public TypesList_Test(ITestOutputHelper debug = null) : base(debug) { }
    }
}