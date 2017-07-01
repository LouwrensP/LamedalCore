using LamdalCoreXunit_lib;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using Xunit.Abstractions;

namespace LamedalCore.Test.Tests.lib
{
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public class lib_Test : xLib
    {
        public lib_Test(ITestOutputHelper debug = null) : base(debug) { }
    }
}