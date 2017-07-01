using LamedalCore;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.Test;
using Xunit;
using Xunit.Abstractions;

namespace LamdalCoreXunit_lib.XML
{
    [Trait("Category", "Lib")]
    [Trait("Category", "LibXML")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public partial class xLibXML : pcTest
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;
        public xLibXML(ITestOutputHelper debug = null) : base(debug) { }
    }
}