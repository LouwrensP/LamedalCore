using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.Types;
using Xunit;

namespace LamedalCore.Test.Tests.types.other
{
    [Trait("Category", "Types")]
    [Trait("Category", "Types Other")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public partial class xTypes_Other
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance; // system library
        private readonly Types_Convert _convert = LamedalCore_.Instance.Types.Convert;
        private readonly Types_ _type = LamedalCore_.Instance.Types;
        private readonly Types_Object _object = LamedalCore_.Instance.Types.Object;

    }
}
