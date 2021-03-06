﻿using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.Test;
using Xunit;
using Xunit.Abstractions;

namespace LamedalCore.Test.Tests.types.Class
{
    [Trait("Category", "Types")]
    [Trait("Category", "Types Class")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public partial class xTypes_Class : pcTest
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        public xTypes_Class(ITestOutputHelper debug = null) : base(debug) { }

    }
}
