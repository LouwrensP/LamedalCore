using LamdalCoreXunit_lib.XML;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using Xunit.Abstractions;

namespace LamedalCore.Test.Tests.lib
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class libXML_Test : xLibXML
    {
        public libXML_Test(ITestOutputHelper debug = null) : base(debug) { }
    }
}