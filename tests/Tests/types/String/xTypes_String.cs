﻿using LamedalCore.domain.Attributes;
using LamedalCore.domain.Enumerals;
using LamedalCore.zPublicClass.Test;
using Xunit;
using Xunit.Abstractions;

namespace LamedalCore.Test.Tests.types.String
{
    [Trait("Category", "Types")]
    [Trait("Category", "Types String")]
    [BlueprintRule_Class(enBlueprint_ClassNetworkType.XUnitTestMethods)]
    public partial class xTypes_String : pcTest
    {
        private readonly LamedalCore_ _lamed = LamedalCore_.Instance;

        public xTypes_String(ITestOutputHelper debug = null) : base(debug) { }
    }
}