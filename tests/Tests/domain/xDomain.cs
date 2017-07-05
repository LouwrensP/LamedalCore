using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using Xunit;

namespace LamedalCore.Test.Tests.domain
{
    [Trait("Category", "domain")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public partial class xDomain
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;
    }
}