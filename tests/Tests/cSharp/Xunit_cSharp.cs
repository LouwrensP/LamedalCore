using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.Test;
using Xunit;
using Xunit.Abstractions;

namespace LamedalCore.Test.Tests.cSharp
{
    [Trait("Category", "cSharp")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public partial class xUnit_cSharp : pcTest
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        public xUnit_cSharp(ITestOutputHelper debug = null) : base(debug) { }
    }
}