using LamedalCore;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.Test;
using Xunit;
using Xunit.Abstractions;

namespace LamdalCoreXunit_lib
{
    [Trait("Category", "Lib")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public partial class xLib : pcTest
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;
        public xLib(ITestOutputHelper debug = null) : base(debug) { }
    }
}