using LamedalCore;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.Test;
using Xunit;
using Xunit.Abstractions;

namespace LamdalCoreXunit_libIO
{
    [Trait("Category", "IO")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public partial class xIO : pcTest
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;
        public xIO(ITestOutputHelper debug = null) : base(debug) { }
    }
}