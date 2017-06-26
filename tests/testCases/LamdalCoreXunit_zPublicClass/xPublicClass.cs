using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamedalCore;
using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using Xunit;

namespace LamdalCoreXunit_zPublicClass
{
    [Trait("Category", "public classes")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public partial class xPublicClass
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

    }
}
