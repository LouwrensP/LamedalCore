using LamedalCore;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass;
using LamedalCore.zPublicClass.Test;
using Xunit;
using Xunit.Abstractions;

namespace LamdalCoreXunit_Types.String
{
    [Trait("Category", "Types")]
    [Trait("Category", "Types List")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public partial class xTypes_String : pcTest
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        public xTypes_String(ITestOutputHelper debug = null) : base(debug) { }
    }
}