using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.Test;
using Xunit;
using Xunit.Abstractions;

namespace LamedalCore.Test.Tests.libIO
{
    [Trait("Category", "IO")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public partial class xLibIO : pcTest
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;
        public xLibIO(ITestOutputHelper debug = null) : base(debug) { }
    }
}