using LamdalCoreXunit_libIO;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using Xunit.Abstractions;

namespace LamedalCore.Test.Tests.lib
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class libIO_Test : xIO
    {
        public libIO_Test(ITestOutputHelper debug = null) : base(debug) { }
    }
}