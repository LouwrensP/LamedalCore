using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.Test;
using Xunit;
using Xunit.Abstractions;

namespace LamedalCore.Test.Tests.zPublicClass
{
    [Trait("Category", "public classes")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public partial class xPublicClass : pcTest
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        public xPublicClass(ITestOutputHelper debug = null) : base(debug) { }

    }
}
