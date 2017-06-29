using LamedalCore;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.Test;
using Xunit;
using Xunit.Abstractions;

namespace LamdalCoreXunit_cSharp.ClassNT
{
    [Trait("Category", "cSharp")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public partial class Xunit_cSharp : pcTest
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        public Xunit_cSharp(ITestOutputHelper debug = null) : base(debug) { }
    }
}